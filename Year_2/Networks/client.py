import socket

#Player commands
#   'Hello': Automatic on startup, initiates handshake.
#   'Game': End of handshake, sent after receiving 'Greetings'. Will start game.
#   'My Guess is: <int>': Sends guess.

def check_ip(ip_addr):
    if len(ip_addr)==4:
        try:
            ip_addr = [int(part) for part in ip_addr]
            if all(part >= 0 and part <= 256 for part in ip_addr):
                return ip_addr
            else:
                print("Please enter a corrent IP address.")
        except ValueError:
            print("Please enter a correct IP address.")
            return False

def get_ip():
    ip_addr = False
    while not ip_addr:
        ip_addr = check_ip(input("What is the server IP?: ").split('.'))
    return ip_addr

class Server:
    def __init__(self, sock=None):
        if sock is None:
            self.sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        else:
            self.sock = sock
        self.port = 4000

    def connect(self, ip_addr):
        self.sock.connect(('.'.join(str(part) for part in ip_addr), self.port))
        return True

    #move to server and delete
    def close(self):
        self.sock.shutdown(socket.SHUT_RDWR)
        self.sock.close()
        return True

    def send(self, msg):
        self.sock.sendall(msg)
        return True

    def receive(self):
        msg = b''
        while not msg.endswith(b'\r\n'):
            msg += self.sock.recv(1024)
        print(msg)
        return msg.decode("utf-8")

    def communicate(self, msg, expected):
        self.send(msg)
        if self.receive().startswith(expected):
            return True

    def make_guess(self, number):
        msg = "My Guess is: {0}\r\n".format(number)
        msg = msg.encode('utf-8')
        self.send(msg)
        response = self.receive()
        if response == "Far":
            print("far")
        elif response == "Close":
            print("close")
        elif response == "Correct":
            print("correct")


def hello(server):
    server.send(b"Hello\r\n")
    msg = server.receive()
    if msg.startswith("Greetings"):
        return True

def game(server):
    server.send(b"Game\r\n")
    msg = server.receive()
    if msg.startswith("Ready"):
        return True

if __name__ == '__main__':
    ip_addr = get_ip()
    server = Server()
    server.connect(ip_addr)
    if server.communicate(b"Hello\r\n", "Greetings"):
        print("Greetings")
        if server.communicate(b"Game\r\n", "Ready"):
            print("Game ready")
            for i in range (0, 101):
                server.make_guess(i)
    server.close()
