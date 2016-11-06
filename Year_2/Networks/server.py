import asyncio, random

connected, user_connected = {}, {}

class Game:
    def __init__(self):
        self.number = self.new_number()
        self.close = 3

    def new_number(self):
        return random.randint(1, 30)

    def make_guess(self, guess):
        distance = abs(self.number - guess)
        if distance == 0:
            return b"Correct\r\n"
        elif distance <= 3:
            return b"Close\r\n"
        elif distance > 3:
            return b"Far\r\n"

class Server(asyncio.Protocol):

    def connection_made(self, transport):
        self.transport = transport
        self.address = transport.get_extra_info('peername')
        if transport.get_extra_info('sockname')[1] == 4000:
            connected[self.address] = "Connected"
            user_connected[self.address] = "User"
        elif transport.get_extra_info('sockname')[1] == 4001:
            connected[self.address] = "Admin"
        self.data = b''

    def data_received(self, data):
        self.data += data
        if self.data.endswith(b'\r\n'):
            if connected[self.address] == "Connected" and self.data == b"Hello\r\n":
                #connected and hello
                connected[self.address] = "Hello"
                self.transport.write(b"Greetings\r\n")
            elif connected[self.address] == "Hello" and self.data == b"Game\r\n":
                connected[self.address] = Game()
                self.transport.write(b"Ready\r\n")
            elif isinstance(connected[self.address], object) and self.data.startswith(b"My Guess is: "):
                try:
                    guess = int(data.split()[-1])
                    answer = connected[self.address].make_guess(guess)
                    self.transport.write(answer)
                except:
                    self.transport.write(b"Far\r\n")
            elif connected[self.address] == "Admin" and self.data == b"Hello\r\n":
                self.transport.write(b"Admin-Greetings\r\n")
            elif connected[self.address] == "Admin" and self.data == b"Who\r\n":
                message = ''
                for user in user_connected.keys():
                    self.transport.write("{} {}\r\n".format(user[0], user[1]).encode())
                self.transport.abort()


            else:
                pass

            self.data = b''

    def connection_lost(self, exc):
        if connected[self.address]:
            del connected[self.address]
        if self.address in user_connected.keys():
            if user_connected[self.address]:
                del user_connected[self.address]
        if exc:
            pass
            #error
        elif self.data:
            pass
            #client sent some data but closed
        else:
            pass
            #print('Client {} closed socket".format(self.address))

if __name__ == '__main__':
    address = ('localhost', 4000)
    loop = asyncio.get_event_loop()
    coro = loop.create_server(Server, *address)
    acoro = loop.create_server(Server, *('localhost', 4001))
    server = loop.run_until_complete(coro)
    aserver = loop.run_until_complete(acoro)
    try:
        loop.run_forever()
    finally:
        server.close()
        aserver.close()
        loop.close()
