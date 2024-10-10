# Design Notes

This is primarily a messaging application, that can use multiple user-interfaces to be able to pass various kinds of messages between multiple clients.

## Basic Components of a Messaging App
There are three maajor parts of messaging app:
### <b>1. Client:</b>
The client are the ui elements that sends and reads packets.

### <b>2. Stream</b>
The network connection between client and server. Aspects of the stream:
#### a. <u>Ports</u>:
###### 1.<i>Network Connection</i> 
		- Need some way to identify ports.
		- Need some local dev environment to test. This can be:
`
IPAddress address = IPAddress.Loopback
`
#### b. <u>Packets</u>:
Need a message object that:
###### <i>1. Creates Packets</i>
		- Needs something to identify the operaton, or the type, of packets.
		- Need some kind of payload.
		- The return trype should be a byte array, since this is what can be sent over a network.
###### <i>2. Parses Packets</i>
		- Needs to take a byte array.
		- Needs to translate that into the operation type and read the payload.

### 3. Server
Need a process that loops to act as the go-between for the clients. Needs:
#### a. <u>Streams</u>
	- In and out streams.
#### b. <u>List of Clients</u>
	- Who will be actually connected to this server.
	- This needs to have some methods to accept new clients.
#### c. <u>A Listener</u>
	- Need an object that is listening over the right kind of network connection
#### d. <u>Sending and Receiving</u>
	- Objects that actually do the sending and the receiving.



