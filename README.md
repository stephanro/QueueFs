# Queue<sup>fs</sup>

Queue<sup>fs</sup> is a simple queue data structure that implements the cannonical approach for functional queues with two lists (inbox, outbox).

## Installation

## Usage

Create a new queue:
```fsharp
let q = Queue.empty
```

Create a new queue and initialize it
```fsharp
let q = Queue.init 1
```

Create a queue from a list:
```fsharp
let q = Queue.fromList [1; 2; 3; 4]
```

Convert a queue to a list:
```fsharp
let l = Queue.toList q
```

Enqueue an item
```fsharp
let q =
    Queue.empty
    |> Queue.enqueue 2
```

Dequeue an item
```fsharp
let q' = Queue.dequeue q
```

Return the next item to be dequeued if there is any:
```fsharp
let i = Queue.peek q
```

Append inbox to outbox:
```fsharp
let q' = Queue.touch q
```

Compose a queue from a tuple:
```fsharp
let q = Queue.fromTuple ([1; 2], [])
```

Decompose a queue into a tuple:
```fsharp
let t = Queue.toTuple q
```