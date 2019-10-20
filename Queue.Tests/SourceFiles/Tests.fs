module Tests


open Queue
open Xunit


[<Fact>]
let ``Queue.empty returns empty queue`` () =
    let expected : obj queue = ([],[]) |> Queue.fromTuple
    let actual : obj queue = Queue.empty
    Assert.Equal (expected, actual)

[<Fact>]
let ``Queue.dequeue of empty list returns empty queue and None`` () =
    let expected : obj queue * obj option = (Queue.fromTuple ([],[]), None)
    let actual : obj queue * obj option =
        Queue.empty
        |> Queue.dequeue
    Assert.Equal (expected, actual)

[<Fact>]
let ``Queue.peek of empty queue returns empty queue and None`` () =
    let expected : obj queue * obj option = (Queue.fromTuple ([],[]), None)
    let actual : obj queue * obj option =
        Queue.empty
        |> Queue.peek
    Assert.Equal (expected, actual)

[<Fact>]
let ``Queue.init with integer value returns empty inbox and outbox with this integer value`` () =
    let expected : int list * int list = ([],[1])
    let actual  : int list * int list =
        Queue.init 1
        |> Queue.toTuple
    Assert.Equal (expected, actual)

[<Fact>]
let ``Queue.enqueue integer value to empty queue returns empty inbox with this integer value and empty outbox`` () =
    let expected : int list * int list = ([1],[])
    let actual  : int list * int list =
        Queue.empty
        |> Queue.enqueue 1
        |> Queue.toTuple
    Assert.Equal (expected, actual)

[<Fact>]
let ``Queue.dequeue returns and removes element and appends inbox to outbox`` () =
    let expected : int queue * int option = (Queue.fromTuple ([],[2; 3; 4]), Some 1)
    let actual : int queue * int option =
        [1; 2; 3; 4]
        |> Queue.fromList
        |> Queue.dequeue
    Assert.Equal (expected, actual)

[<Fact>]
let ``Queue.peek returns element and appends inbox to outbox`` () =
    let expected  : int queue * int option = (Queue.fromTuple ([],[1; 2]), Some 1)
    let actual : int queue * int option =
        Queue.empty
        |> Queue.enqueue 1
        |> Queue.enqueue 2
        |> Queue.peek
    Assert.Equal (expected, actual)

[<Fact>]
let ``Queue.touch of empty list does not change state of queue`` () =
    let expected : obj queue = Queue.empty
    let actual : obj queue =
        Queue.empty
        |> Queue.touch
    Assert.Equal (expected, actual)

[<Fact>]
let ``Queue.touch moves inbox to outbox`` () =
    let expected : int queue = Queue.fromTuple ([],[1; 2])
    let actual : int queue = 
        Queue.empty
        |> Queue.enqueue 1
        |> Queue.enqueue 2
        |> Queue.touch
    Assert.Equal (expected, actual)

[<Fact>]
let ``Queue.touch appends inbox to outbox`` () =
    let expected : int queue = Queue.fromTuple ([],[1; 2; 3; 4])
    let actual : int queue =
        Queue.empty
        |> Queue.enqueue 1
        |> Queue.enqueue 2
        |> Queue.touch
        |> Queue.enqueue 3
        |> Queue.enqueue 4
        |> Queue.touch
    Assert.Equal (expected, actual)

[<Fact>]
let ``Queue.fromList composes queue from list`` () =
    let expected : int queue = Queue.fromTuple ([],[1; 2])
    let actual : int queue = 
        [1; 2]
        |> Queue.fromList
    Assert.Equal (expected, actual)

[<Fact>]
let ``Queue.toList decomposes queue to list`` () =
    let expected : int list = [1; 2]
    let actual : int list =
        [1; 2]
        |> Queue.fromList
        |> Queue.toList
    let condition : bool =
        expected = actual
    Assert.True (condition)

[<Fact>]
let ``Queue.toTuple decomposes queue to tuple`` () =
    let expected : int list * int list = ([2; 1], [])
    let actual : int list * int list =
        Queue.empty
        |> Queue.enqueue 1
        |> Queue.enqueue 2
        |> Queue.toTuple
    Assert.Equal (expected, actual)

[<Fact>]
let ``Queue.fromTuple composes queue from tuple``() =
    let expected : int queue =
        Queue.empty
        |> Queue.enqueue 1
        |> Queue.enqueue 2
    let actual : int queue = Queue.fromTuple ([2; 1], [])
    Assert.Equal(expected, actual)