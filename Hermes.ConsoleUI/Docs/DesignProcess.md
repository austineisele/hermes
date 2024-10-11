# Design Process

## 1. Get Primitive app working.
See this: [Creating a multi-user chat app](https://medium.com/@va.riley/building-a-simple-multi-user-chat-application-and-server-in-c-in-3-steps-b33dee824000)
### Architecture:
#### i. ConsoleUI: this the client
	This is simply the view for the server object.
#### ii. Infrastructure: this is the stream. It includes these objects:
##### a. Constants - for port information
##### b. Messenger - object that allows packets to be created and sent
#### iii. Server:	
	The network serving the packets.
## 2. Look for Families of Objects