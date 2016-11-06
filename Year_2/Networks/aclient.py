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
        self.port = 4001
    def connect(self, ip_addr):
        self.sock.connect(('.'.join(str(part) for part in ip_addr), self.port))
        return True
    def send(self, msg):
        try:
            self.sock.sendall(msg)
            return True
        except ConnectionResetError:
            print("Server closed the connection")
            return False
    def receive(self):
        msg = b''
        while not msg.endswith(b'\r\n'):
            try:
                msg += self.sock.recv(1024)
            except ConnectionAbortedError:
                print("Server closed the connection")
                return False
        return msg.decode("utf-8")
    def communicate(self, msg, expected):
        if self.send(msg):
            msg = self.receive()
            if msg:
                if msg.startswith(expected):
                    return True
                else:
                    return False
            else:
                return False
    def handshake(self):
        if server.communicate(b"Hello\r\n", "Admin-Greetings"):
            return True
if __name__ == '__main__':
    ip_addr = get_ip()
    server = Server()
    server.connect(ip_addr)
    if server.handshake():
        server.send(b'Who\r\n')
        message = server.receive()
        print("The players currently playing are:")
        try:
            splitm = message.split(' ')
            for i, k in zip(splitm[0::2], splitm[1::2]):
                print("{}:{}".format(i, k))
        except:
            print(message)
