import socket, random

class Guess:
    def __init__(self):
        self.number = self.new_number()
        self.close = 20
        self.guesses = 0

    def new_number(self):
        return random.randint(1, 100)

    #move to client and delete guess counter
    def make_guess(self, guess):
        self.guesses += 1
        if guess == self.number:
            return b"Correct\r\n"
        elif (self.number - guess <= self.close or guess - self.number <= self.close):
            return b"Close\r\n"
        else:
            return b"Far\r\n"


class Server:
    def __init__(self, sock=None):
        if sock is None:
            self.sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        else:
            self.sock = sock
        self.port = 4000
        self.aport = 4001
        self.games = {}
        self.connected = []

    def close(self, conn):
        self.connected.remove(conn.getpeername())
        conn.shutdown(socket.SHUT_RDWR)
        conn.close()
        return True

    def send(self, conn, msg):
        conn.sendall(msg)
        return True

    def listen(self):
        self.sock.bind(('', self.port))
        self.sock.listen(5)
        conn, addr = self.sock.accept()
        while conn:
            if addr not in self.connected:
                self.connected.append(addr)
            data = b''
            while not data.endswith(b'\r\n'):
                data += conn.recv(1024)
            msg = data.decode("utf-8")
            if msg == "Hello\r\n":
                self.send(conn, b'Greetings\r\n')
                print("Greetings")
                data = b''
            elif msg == "Game\r\n":
                self.games[conn] = Guess()
                self.send(conn, b'Ready\r\n')
                print("Ready")
                data = b''
            elif msg.startswith("My Guess is: "):
                try:
                    guess = int(msg.split()[-1])
                except ValueError:
                    guess = 999
                answer = self.games[conn].make_guess(guess)
                print("Guess")
                self.send(conn, answer)
                if answer == b"Correct\r\n":
                    self.close(conn)
                data = b''


if __name__ == '__main__':
    server = Server()
    server.listen()
