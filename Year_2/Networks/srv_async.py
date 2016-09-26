#!/usr/bin/env python3

import socket, select, random

class Guess:
    def __init__(self):
        self.number = self.new_number()
        self.close = 5
        print(self.number)

    def new_number(self):
        return random.randint(1, 30)

    def make_guess(self, guess):
        if guess == self.number:
            return b"Correct\r\n"
        elif (guess < self.number and self.number - guess <= self.close) or (guess > self.number and guess - self.number <= self.close):
            return b"Close\r\n"
        else:
            return b"Far\r\n"

def create_srv_socket(address):
    """Build and return a listening server socket."""
    listener = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    listener.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
    listener.bind(address)
    listener.listen(64)
    print("Listening at {}".format(address))
    return listener

def all_events_forever(poll_object):
    while True:
        for fd, event in poll_object.poll():
            yield fd, event

def serve(listener, alistener):
    sockets = {listener.fileno(): listener, alistener.fileno(): alistener}
    addresses = {}
    bytes_received = {}
    bytes_to_send = {}
    games = {}
    admins = []

    poll_object = select.poll()
    poll_object.register(listener, select.POLLIN)
    poll_object.register(alistener, select.POLLIN)

    for fd, event in all_events_forever(poll_object):
        sock = sockets[fd]
        print(sock.getsockname())

        # Socket closed, remove from data structures

        if event & (select.POLLHUP | select.POLLERR | select.POLLNVAL):
            address = addresses.pop(sock)
            rb = bytes_received.pop(sock, b'')
            sb = bytes_to_send.pop(sock, b'')
            if rb:
                print("Client {} sent {} but then closed".format(address, rb))
            elif sb:
                print("Client {} closed before we send {}".format(address, sb))
            else:
                print("Client {} closed socket normally".format(address))
            if sock in admins:
                admins.remove(sock)
            if sock in games:
                del games[sock]
            poll_object.unregister(fd)
            del sockets[fd]

        #new socket, add to data structures

        elif sock is listener:
            sock, address = sock.accept()
            print("Accepted connection from {}".format(address))
            sock.setblocking(False) #socket.timeout if mistake
            sockets[sock.fileno()] = sock
            addresses[sock] = address
            poll_object.register(sock, select.POLLIN)

        # Incoming data, keep receiving until we see the suffix.

        elif event & select.POLLIN:
            more_data = sock.recv(4096)
            if not more_data: #EOF
                sock.close()
                continue
            data = bytes_received.pop(sock, b'') + more_data
            if data.endswith(b'\r\n'):
                if data == b'Hello\r\n':
                    print(sock.getsockname())
                    if sock.getsockname()[1] == 4000:
                        bytes_to_send[sock] = b'Greetings\r\n'
                    elif sock.getsockname()[1] == 4001:
                        bytes_to_send[sock] = b'Admin-Greetings\r\n'
                        print("Sending admin greetings")
                        admins.append(sock)
                elif data == b'Game\r\n':
                    games[sock] = Guess()
                    bytes_to_send[sock] = b'Ready\r\n'
                elif data.startswith(b'My Guess is: '):
                    try:
                        guess = int(data.split()[-1])
                    except ValueError:
                        guess = 999
                    answer = games[sock].make_guess(guess)
                    print("Guess {}".format(answer))
                    bytes_to_send[sock] = answer
                elif data == b'Who\r\n' and sock in admins:
                    for address in addresses:
                        bytes_to_send[sock] += address
                else:
                    print("wtf {}".format(data))
                    bytes_to_send[sock] = b'WTF?\r\n'
                poll_object.modify(sock, select.POLLOUT)
            else:
                bytes_received[sock] = data

        # Socket ready to send: keep sending until all bytes are delivered.

        elif event & select.POLLOUT:
            data = bytes_to_send.pop(sock, b'')
            n = sock.send(data)
            if n<len(data):
                bytes_to_send[sock] = data[n:]
            elif data == b"Correct\r\n":
                sock.close()
            else:
                poll_object.modify(sock, select.POLLIN)

if __name__ == '__main__':
    listener = create_srv_socket(('127.0.0.1', 4000))
    alistener = create_srv_socket(('127.0.0.1', 4001))
    serve(listener, alistener)
