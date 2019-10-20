# Queue<sup>fs</sup>

Queue<sup>fs</sup> is a simple queue data structure that implements the cannonical approach for functional queues with two lists (inbox, outbox).

## Usage

Create a new queue:
```fsharp
let q : int queue = Queue.empty
val q : int queue = Queue ([],[])
```

Create a new queue and initialize it
```fsharp
let q = Queue.init 1
val q : int queue = Queue ([],[1])
```

Create a queue from a list:
```fsharp
let q = Queue.fromList [1; 2; 3; 4]
val q : int queue = Queue ([],[1; 2; 3; 4])
```

Convert a queue to a list:
```fsharp
let l = Queue.toList q
val l : int list = [1; 2; 3; 4]
```

Enqueue an item
```fsharp
let q =
    Queue.empty
    |> Queue.enqueue 2
val q : int queue = Queue ([2],[])
```

Dequeue an item
```fsharp
let q' = Queue.dequeue q
val q' : int queue * int option = (Queue ([],[2; 3; 4]), Some 1)
```

Return the next item to be dequeued if there is any:
```fsharp
let (q', i) = Queue.peek q
val q' : int queue = Queue ([],[2; 3; 4])
val i : int option = Some 2

```

Append inbox to outbox:
```fsharp
let q = Queue.fromTuple ([4; 3],[1; 2])
val q : int queue = Queue ([4; 3],[1; 2])
let q' = Queue.touch q
val q' : int queue = Queue ([],[1; 2; 3; 4])
```

Compose a queue from a tuple:
```fsharp
let q = Queue.fromTuple ([4; 3],[1; 2])
val q : int queue = Queue ([4; 3],[1; 2])

```

Decompose a queue into a tuple:
```fsharp
let t = Queue.toTuple q
val t : int list * int list = ([4; 3],[1; 2])
```