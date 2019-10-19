module Queue

    type 'a queue =
        private Queue of inbox : 'a list * outbox : 'a list

    
    
    /// **Description**
    ///   * Returns an empty queue
    /// 
    /// **Parameters**
    ///
    ///
    /// **Output Type**
    ///   * `'a queue`
    ///
    /// **Exceptions**
    ///
    let empty : 'a queue =
        Queue (List.empty, List.empty)
    

    
    /// **Description**
    ///   * Returns a queue with an initial item
    /// 
    /// **Parameters**
    ///   * `a` - parameter of type `'a`
    ///
    /// **Output Type**
    ///   * `'a queue`
    ///
    /// **Exceptions**
    ///
    let init (a : 'a) : 'a queue =
        Queue (List.empty, [a])


    /// **Description**
    ///   * Adds an element to the end of the queue.
    /// 
    /// **Parameters**
    ///   * `a` - parameter of type `'a`
    ///   * `q` - parameter of type `'a queue`
    ///
    /// **Output Type**
    ///   * `'a queue`
    ///
    /// **Exceptions**
    ///
    let enqueue (a : 'a) (q : 'a queue) : 'a queue =
        match q with
        | Queue (inbox, outbox) ->
            Queue (a::inbox, outbox)

    
    /// **Description**
    ///   * Returns and removes the first element of the queue,
    ///   * or none in case the queue is empty.
    ///   * Returns the new state of the queue as well.
    /// 
    /// **Parameters**
    ///   * `q` - parameter of type `'a queue`
    ///
    /// **Output Type**
    ///   * `'a queue * 'a option`
    ///
    /// **Exceptions**
    ///
    let rec dequeue (q : 'a queue) : 'a queue * 'a option =
        match q with
        | Queue ([], []) ->
            (q, None)
        | Queue (inbox, []) ->
            let outbox = List.rev inbox
            Queue (List.empty, outbox) |> dequeue
        | Queue (inbox, a::outbox') ->
            let q' : 'a queue = Queue (inbox, outbox')
            (q', Some a)

    
    /// **Description**
    ///   * Returns the first element of the queue without removing it,
    ///   * or none in case the queue is empty.
    ///   * Returns the new state of the queue as well.
    /// 
    /// **Parameters**
    ///   * `q` - parameter of type `'a queue`
    ///
    /// **Output Type**
    ///   * `'a queue * 'a option`
    ///
    /// **Exceptions**
    ///
    let peek (q : 'a queue) : 'a queue * 'a option =
        match dequeue q with
        | (_, None) ->
            (q, None)
        | (q', Some a) ->
            match q' with
            | Queue (inbox, outbox) ->
                let q'' : 'a queue = Queue (inbox, a::outbox)
                (q'', Some a)

    
    /// **Description**
    ///   * Moves or appends inbox to outbox
    /// 
    /// **Parameters**
    ///   * `q` - parameter of type `'a queue`
    ///
    /// **Output Type**
    ///   * `'a queue`
    ///
    /// **Exceptions**
    ///
    let touch (q : 'a queue) : 'a queue =
        match q with
        | Queue (inbox, outbox) ->
            let outbox' : 'a list =
                inbox
                |> List.rev
                |> List.append outbox
            Queue (List.empty, outbox')

    
    /// **Description**
    ///   * Converts a list to a queue
    /// 
    /// **Parameters**
    ///   * `outbox` - parameter of type `'a list`
    ///
    /// **Output Type**
    ///   * `'a queue`
    ///
    /// **Exceptions**
    ///
    let fromList (outbox : 'a list) : 'a queue =
        Queue (List.empty, outbox)
    
    
    /// **Description**
    ///   * Converts a queue to a list
    /// 
    /// **Parameters**
    ///   * `q` - parameter of type `'a queue`
    ///
    /// **Output Type**
    ///   * `'a list`
    ///
    /// **Exceptions**
    ///
    let toList (q : 'a queue) : 'a list =
        match touch q with
        | Queue (_, outbox) ->
            outbox


    
    /// **Description**
    ///   * Converts a tuple into a queue
    /// 
    /// **Parameters**
    ///   * `t` - parameter of type `'a list * 'a list`
    ///
    /// **Output Type**
    ///   * `'a queue`
    ///
    /// **Exceptions**
    ///
    let fromTuple (t : 'a list * 'a list) : 'a queue =
        match t with
        | (inbox, outbox) -> Queue (inbox, outbox)


    
    /// **Description**
    ///
    /// **Parameters**
    ///   * `q` - parameter of type `'a queue`
    ///
    /// **Output Type**
    ///   * `'a list * 'a list`
    ///
    /// **Exceptions**
    ///
    let toTuple (q : 'a queue) : 'a list * 'a list =
        match q with
        | Queue (inbox, outbox) -> (inbox, outbox)