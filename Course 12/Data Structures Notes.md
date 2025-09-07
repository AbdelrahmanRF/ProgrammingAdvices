---

# Data Structures

---

## What is Data Structure? and Why?

### What is Data Structure?

**Data Structure** : is a way of organizing all data items and their relationships to each others inside the program in order to deal with them.

**Data Structure** : both structural and functional aspects of the program.

**Data Structure** : is how u organize, manage and store data for efficiency reasons.

**Data Structure** : is not only used for organizing the data. It is also used for processing, retrieving, and storing data. 

There are different basic and advanced types of data structures that are used in almost every program or software system that has been developed. So we must have good knowledge of data structures. 

- **Data Structure** are an integral part of computers used for the arrangement of data in memory. 

    They are essential and responsible for organizing, processing, accessing, and storing data efficiently. But this is not all.

- Various types of data structures have their own characteristics, features, applications, advantages, and disadvantages.

### Why Data Structures?

**Efficiency**: Choosing the right data structure makes programs faster and reduces memory usage.

**Organization**: Helps maintain relationships between data items (e.g., a graph for networks, a tree for hierarchies).

**Scalability**: Allows handling large and complex data sets in real-world applications.

**Problem Solving**: Many algorithms are designed specifically for certain data structures (e.g., Dijkstra’s algorithm on graphs).

**Reusability**: Well-designed structures can be reused across programs and applications.

---

## Differences between Data Structures and Database

### 1. Definition

- **Data Structure**:

    A way to organize and store data in memory (RAM) for efficient processing during program execution.

    Examples: Arrays, Linked Lists, Stacks, Queues, Trees, Graphs, Hash Tables.

- **Database**:

    A system (usually software) used to store, manage, and retrieve large amounts of data permanently (on disk/storage).

    Examples: MySQL, Oracle, MongoDB, PostgreSQL.

<br>

### 2. Purpose

- **Data Structure**: Focuses on efficient access, modification, and processing of data while the program is running.

- **Database**: Focuses on persistent storage, querying, and management of data even after the program stops running.

<br>

### 3. Storage

- **Data Structure**: Data is usually stored in memory (RAM) → temporary, fast access.

- **Database**: Data is stored on disk or cloud storage → permanent, can survive power loss.

<br>

### 4. Scale

- **Data Structure**: Works with data that fits in memory, usually for program-level operations.

- **Database**: Works with huge datasets, often involving millions of records and multiple users.

<br>

### 5. Operations

- **Data Structure**: Searching, sorting, insertion, deletion, traversal.

- **Database**: CRUD operations (Create, Read, Update, Delete) using query languages (like SQL).

<br>

### 6. Examples in Use

- **Data Structure**:

    - Stack for undo/redo in an editor

    - Queue for task scheduling

    - Graph for social networks

- **Database**:

    - MySQL database storing user accounts

    - MongoDB storing product catalog for an e-commerce site

---

## What are the Classification/Types of Data Structures?

### Classification of Data Structures

#### 1. Primitive (Basic) Data Structures

- Examples:

    **Integer**

    **Float / Double**

    **Character**

   **Boolean**

#### 2. Non-Primitive (Advanced) Data Structures

- Two main categories:

    **Linear Data Structures**

    **Non-Linear Data Structures**

### Differences

- **A primitive data structure :**

    Is generally a basic structure that is usually built into the language, such as an integer, a float.

- **A non—primitive data structure :**

    IS built out of primitive data structures linked together in meaningful ways such as a or a arrays, linked—list, binary search tree, Tree, graph etc.

### Non-Primitive Data Structures

**1. Linear Data Structures**

- Elements arranged sequentially.

- Examples:

    - **Array**

    - **Linked List**

    - **Stack**

    - **Queue**

<br>

**2. Non-Linear Data Structures**

- Elements connected non-sequentially (hierarchical or network).

- Examples:

    - **Tree**

    - **Graph**

    - **Hash Table**

- Complex/Sophisticated Data Structure derived from primitive data structure.

### Homogeneous vs. Heterogeneous Data

- **Homogeneous**: All data items are of the same type.

    - Example: Array of integers → `[1, 2, 3, 4].`

- **Heterogeneous**: Data items can be of different types.

    - Example: Structure in C++ or Objects in OOP → `{Name: "Ali", Age: 23, GPA: 3.5}.`

### Linear vs. Non-Linear Data Structures

**1. Linear Data Structures**

- Data elements are arranged sequentially (one after another).

- Each element has a single predecessor and a single successor (except the first and last).

- Easy to implement, but not always memory-efficient.

- Examples:

    - **Array** → fixed-size, indexed sequentially

    - **Linked List** → nodes connected in sequence

    - **Stack** → LIFO (Last In, First Out)

    - **Queue** → FIFO (First In, First Out)

- Use Cases:

    - Task scheduling (Queue)

    - Undo/Redo operations (Stack)

    - Iterating through ordered data

**2. Non-Linear Data Structures**

- Data elements are arranged hierarchically or in a network (not sequential).

- Each element can be connected to multiple elements.

- More complex but better for representing real-world relationships.

- Examples:

    - **Tree** → hierarchical (root → children → grandchildren)

    - **Graph** → network of nodes connected by edges

    - **Hash Table** → key-value mapping (not sequential)

- Use Cases:

    - File systems (Tree)

    - Social networks, maps, routes (Graph)

    - Fast lookups (Hash Tables)

### Static vs. Dynamic Data Structures

- **Static Data Structures**

    - Fixed memory size.

    - Easier to allocate items.

    - Memory allocated at compile time.

    - Example: Array.

- **Dynamic Data Structures**

    - Size can grow or shrink at runtime.

    - Memory allocated at runtime, which may be considered efficient concerning the memory (space) complexity of the code.

    - Examples: Linked List, Stack, Queue, Tree, Graph.

### Common Operations on Data Structures

Almost every data structure supports these basic operations:

- **Traversal** → Accessing each element once.

- **Insertion** → Adding a new element.

- **Deletion** → Removing an element.

- **Searching** → Finding an element.

- **Sorting** → Arranging elements in order.

- **Merging** → Combining two structures.

- **Updating** → Modifying existing data.

---

## Things Affect Program Speed & Efficiency

**1. What Affects Program Speed?**

Program speed is influenced by:

- **Algorithm** (our main concern)

- **Hardware** (CPU, Memory, OS, etc.)


**2. What Affects Algorithm Speed?**

An algorithm’s efficiency is measured in two main aspects:

- **Time Complexity** → How much time the algorithm takes as the input size grows.

- **Space Complexity** → How much memory (RAM) the algorithm consumes as the input size grows.

**3. Why Focus on Time & Space?**

Hardware improvements can make execution faster, but a **bad algorithm** will still be slow for large inputs.

Efficient algorithms save:

- **Execution Time**

- **System Resources**

---

## Time & Space Complexity - Big O Notation

**1. What is Big O?**

- Big O notation describes the efficiency of an algorithm in terms of:

    - **Time Complexity** → How execution time grows with input size.

    - **Space Complexity** → How memory usage grows with input size.

- Expressed as O(f(n)), where:

    - O = Order Of

    - n = Input size

    - f(n) = Function that describes growth rate

**2. What Big O is NOT**

- Does not give the exact runtime.

- Does not consider hardware speed (CPU, RAM, OS, etc.).

- Instead, it shows the rate of growth of resource usage as input size increases.

**3. Time & Space Complexity**

- **Time Complexity** → Number of computational steps an algorithm takes as a function of input size.

- **Space Complexity** → Amount of memory an algorithm uses as a function of input size.

**4. What is Big O Notation?**

- Big O = “Order Of”.

- Represents the worst-case scenario of an algorithm.

- Provides an algebraic way to describe efficiency.

- Shows the relationship between input size and performance.

- Lets us compare algorithms independent of hardware.

**5. Key Points**

- Big O helps answer:

    - “How does runtime grow as input increases?”

    - “How much memory will this algorithm need?”

- Examples:

    - O(1) → Constant time (fastest)

    - O(log n) → Logarithmic

    - O(n) → Linear

    - O(n log n) → Linearithmic

    - O(n²) → Quadratic

    - O(2ⁿ), O(n!) → Exponential / Factorial (slowest)

---

## Big O(1) : Constant Time Function

**Example Algorithm**

```c++
char GetLastCharacter(string S1) {
    return S1[S1.length() - 1];
}
```

**Step Analysis**

When this function executes, the number of steps is **always the same**, no matter how big the string is.

- S1.length() → 1 step

- S1.length() - 1 → 1 step

- S1[...] (array access at index) → 1 step

- return → 1 step

**Total = 4 steps**


**Simplification Rules**

- Each basic operation (+, -, =, return, array access) counts as O(1).

- Multiply by constant → 4 * O(1)

- In Big O, constants are ignored (we only care about growth as input increases).

So:

```c++
4 * O(1) → O(1)
```

**Why O(1)?**

- The number of steps is constant.

- Input size (length of string n) does not change the number of operations.

- Whether the string has 10 characters or 1 million, the function always takes the same amount of time.

**Therefore, this algorithm runs in constant time → O(1).**

---

## Big O(n) : Linear Time Function

**Example Algorithm**

```c++
char GetLastCharacter2(string S1) {
    int n = S1.length() - 1;

    for (int i = 0; i <= n; i++) {
        if (i == n) {
            return S1[n];
        }
    }
}
```

**Step Analysis**

- **Steps outside the loop (executed once):**

    - S1.length() → 1 step

    - S1.length() - 1 → 1 step

    - assignment int n = ... → 1 step

    - assignment int i = ... → 1 step

    **Total = 4 steps**

- **Steps inside the loop (executed n+1 times worst-case):**

    - i <= n (comparison) → 1 step
    - if (i == n) → 1 step
    - n (fetch variable value) → 1 step
    - S1[...] (array access at index) → 1 step
    - return → 1 step
    - i++ (increment) → 1 step

    **Total inside loop = 6n steps**

**Total Complexity**

```c++
T(n) = (6n + 4) steps
```

**Simplification**

- **Remove constants → `+4` ignored.**

- **Remove coefficients → `6n` simplified to `n`.**

**Final Complexity:**

```c++
O(n)
```

**Why O(n)?**

- As input size `n` grows, the number of operations grows linearly.

- If the string doubles in size, the steps approximately double.

- This is the essence of linear time complexity.

---

### Big O(n^2) : Quadratic Time Function

**Example Algorithm**

```c++
int MultiplicationShort()
{
    int Sum = 0;
    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= n; j++)
        {
            Sum = Sum + (i * j);
        }
    }
    return Sum;
}
```

**Step Analysis**

- **Outside loops**

    - int Sum = 0 → 1 step

    - first for init (i = 1) → 1 step

    - Sum (fetch variable value) → 1 step

    - final return → 1 step

    **So, cost = 4**

- **Inner Loop 1**

    - i <= n comparison → 1 step

    - i++ increment → 1 step

    - int j = 1 → 1 step

    - body (the whole inner loop) → n

    **So, cost = (3 + n)**

- **Inner loop 2**

    - j <= n (comparison) → 1 step

    - i * j (multiplication) → 1 step

    - Sum + ... (addition) → 1 step

    - Sum = ... (assignment) → 1 step

    - j++ (increment) → 1 step

    **Total = 5n -> n**

**Total inner loop per outer iteration**

** n from loop 2 **

```c++
n * (3 + n) = 3n + n^2 -> n^2
```

**Combine All**

```c++
4 + n^2 -> O(n^2)
```

---

## Big O(Log n) : Logarithmic Time Function

**What do we mean by log?**

- x^2 -> double itself

- Log2 -> half itself

**Example Algorithm**

```c++
void func(short x)
{
    short n = x;           
    while (x > 0)           
    {
        x = x / 2;          
        cout << x << endl;
    }
}
```

**Step Analysis**

- **Outside the Loop**

    - short n = x; → 1 step

    **Total outside loop = 1 step**

- **Inside the Loop**

    - x > 0 (comparison) → 1 step
    - x / 2 (divide) → 1 step
    - x = ... (assignment) → 1 step
    - x (fetch variable value) → 1 step
    - cout x (print value) -> 1 step
    - endl (prepare endline) -> 1 step
    - cout endl (output newline) -> 1 step

    **Total 7 steps per iteration**
    **cost = 7 * log n -> log n**

**Overall Complexity**

```c++
1 + log n -> O(log n)
```

---

## Binary Data Structure

### 1. What Does It Mean?

- Normally, we think of data structures as arrays, stacks, queues, etc.

- But binary itself (bits 0 and 1) can be organized to represent information → making it a “data structure”.

- This is often called a bitmask or flag system.

- Each bit in an integer represents whether a feature/permission/option is ON (1) or OFF (0).


### Example: Access Permissions

Instead of storing many bool variables like:

```c++
bool canListClients;
bool canAddClient;
bool canDeleteClient;
bool canUpdateClient;
...
```

We can store all of them in one integer, using binary encoding.

```c++
enum enPermissions {
    eAll = -1,
    pListClients      = 1,    // 0000 0001
    pAddNewClient     = 2,    // 0000 0010
    pDeleteClient     = 4,    // 0000 0100
    pUpdateClients    = 8,    // 0000 1000
    pFindClient       = 16,   // 0001 0000
    pTransactions     = 32,   // 0010 0000
    pManageUsers      = 64,   // 0100 0000
    pCurrencyExchange = 128,  // 1000 0000
    pLoginRegister    = 256   // 1 0000 0000
};
```
Here each bit corresponds to one permission.

### 3. Example Function: Checking Permission

```c++
bool CheckAccessPermission(enPermissions Permission) {
    if (this->Permissions == eAll)
        return true;

    if ((Permission & this->Permissions) == Permission)
        return true;
    else
        return false;
}
```

**Explanation**

- `&` (bitwise AND) is used to test if a **specific bit is set**.

- Example:

    - Permissions = 5 → binary 0101 (has pListClients=1 and pDeleteClient=4).

    - Check pDeleteClient (4) → 5 & 4 = 4 ✅ allowed.

    - Check pAddNewClient (2) → 5 & 2 = 0 ❌ not allowed.

### 4. Why is Binary Useful as a Data Structure?

- Memory Efficient → one integer can hold 32 or 64 flags instead of 32/64 booleans.

- Fast Operations → bitwise &, |, ^ are very fast.

- Compact Representation → easy to store, transfer, and check multiple conditions.

- Real-Life Usage:

    - File system permissions (rwx in Linux).

    - User roles and security systems.

    - Feature toggles in software.

    - Compression and cryptography.

---

## Array Data Structure

### What is an Array?

- An array is a variable that can store multiple values of the same type.

- It is a collection of data items stored at contiguous memory locations.

- Arrays store homogeneous data (same type elements) together.

### Is an Array Always Fixed Size?

**Depends on they language** for example:

- C language → Array has a fixed size. Once declared, it cannot shrink or expand.

- C++ language → Supports both fixed-size arrays and dynamic arrays (using pointers, new, or containers like std::vector).

**Operations on Arrays**

- Arrays allow random access to elements (direct indexing).

- This makes operations like searching, insertion (at index), and access efficient.

- Array elements can be accessed easily using loops.

### Time Complexities in Arrays

**1. Insertion**

Insert value at a specific index.

```c++
arr[2] = 18;
```

**Time Complexity:**

O(1) → inserting a single element

O(N) → inserting all elements (where N = size of array)


**2. Access**

Directly access element by index.

```c++
return arr[2];
```

**Time Complexity:**

O(1) → access a single element

O(N) → access all elements

**3. Searching**

Must check elements one by one (linear search).

```c++
// Searching for value 55
for (int i = 0; i < n; i++) {
    if (arr[i] == 55) return true;
}
```

**Time Complexity: O(N)**


### Applications of Arrays

- Storing elements of the same data type.

- Useful when the size of the dataset is known.

- Solving matrix problems.

- Applied as a lookup table in computers.

- Database records often use arrays.

- Used in sorting algorithms.

- Grouping variables of the same type under one name.

- Used for Computer Graphics (CGR).

- Basis for implementing other data structures: Stacks, Queues, Heaps, Hash Tables, etc.

---

## Matrix Data Structure

**Matrix**: A matrix is a 2D array where elements are arranged in rows and columns.

Elements are stored in contiguous memory locations, just like arrays.

Each element is accessed using two indices: row index and column index.

### Time Complexity on The Matrix

**1. Insertion**

Insert value at a specific matrix index.

```c++
arr[2][1] = 18;
```

**Time Complexity:**

O(1) → inserting a single element (random access).

O(N²) → inserting all elements in an N x N matrix.


**2. Access**

```c++
return arr[2][1];
```

**Time Complexity:**

O(1) → accessing a single element.

O(N²) → accessing all elements.

**3. Searching**

```c++
// Searching for value 55 in an N x N matrix
for (int i = 0; i < N; i++) {
    for (int j = 0; j < N; j++) {
        if (arr[i][j] == 55) return true;
    }
}
```
**Time Complexity: O(N²)**


**Applications of Matrices**

- Representing graphs in adjacency matrix form.

- Used in computer graphics (image processing, transformations).

- Solving mathematical problems (linear algebra, matrix multiplication).

- Used in dynamic programming (DP tables).

- Representing maps, grids, and game boards.

---

## Vector Data Structure

### Definition

- **A dynamic array** (resizable array).

- Unlike normal arrays (fixed size), vectors can **grow or shrink** at runtime.

- Provides **random access** (like arrays) and **automatic resizing** when capacity is exceeded.


### Key Characteristics

- **Contiguous memory allocation** (like arrays).

- **Dynamic resizing** → automatically doubles capacity when full.

- **Homogeneous elements** → all elements are of the same type.

- **Efficient access** → direct indexing using `[]`.

---

## Stack Data Structure

A **linear data structure** that follows the principle:

**LIFO (Last In, First Out)** → the last element inserted is the first one removed.


### Basic Operations

- **push(x)** → insert element x at the top.

- **pop()** → remove the element at the top.

- **top() / peek()** → view the element at the top without removing it.

- **bottom()** → view the first element inserted (not always supported in standard implementations).

- **empty()** → check if the stack is empty.

- **size()** → return the number of elements in the stack.

### Common Time Complexities

| Operation            | Complexity         |
| -------------------- | ------------------ |
| Access by index      | **O(1)**           |
| Update by index      | **O(1)**           |
| Append at end        | **Amortized O(1)** |
| Insert/Delete middle | **O(n)**           |
| Search (linear)      | **O(n)**           |


### Examples in Real Life

- **Call Stack** (function calls in programming):

    - When a function is called, it’s pushed onto the stack.

    - When it finishes, it’s popped off.

- **Undo / Redo operations** in text editors.

- **Browser history** (Back button).

- **Balancing parentheses in compilers**.


### Implementation

Can be implemented using:

- **Array / Vector** (dynamic resizing).

- **Linked List** (flexible, no size limit).

---

## Queue Data Structure

A Queue is a **linear data structure** that follows the principle:

**FIFO (First In, First Out)**

The **first element inserted** is the **first element removed**.

A **real-world queue (line at a supermarket)**:

- People enter from the back.

- People leave from the front.

### Basic Operations

- **push / enqueue** → Insert an element at the back of the queue.

- **pop / dequeue** → Remove the element from the front of the queue.

- **front / peek** → Access the element at the front without removing it.

- **back** → Access the last element.

- **size** → Number of elements in the queue.

- **empty** → Checks whether the queue has no elements.

### Time Complexity

| Operation         | Complexity |
| ----------------- | ---------- |
| Enqueue           | **O(1)**   |
| Dequeue           | **O(1)**   |
| Access front/back | **O(1)**   |
| Size/Empty        | **O(1)**   |


### Real-Life Examples of Queues

- **Print queue** → documents get printed in the order submitted.

- **Task scheduling** in operating systems.

- **Customer service line** (first customer served first).

- **Breadth-first search (BFS)** in graphs.

- **Data buffers** (e.g., streaming, IO operations).

---


## Singly Linked List

**A Singly Linked List (SLL)** is a **linear data structure** made of nodes, where:

- Each **node** contains:

    1. **Data** (the value you want to store).

    2. **Next pointer** (a reference to the next node in the list).

- The **last node** points to **NULL** (end of the list).

Unlike arrays, linked lists do not use contiguous memory → they are dynamic in size.


### Basic Operations

**1. Insert At Beginning**

- Create a new node.

- Point its next to the current head.

- Update head to this new node.

- **Time Complexity: O(1)**


**2. Find (Search)**

- Traverse the list from head until you find the value or reach the end.

- **Time Complexity: O(n)**

**3. Insert After (insert a node after a given node)**

- Find the target node.

- Update new node’s next to point to target’s next.

- Update target’s next to point to the new node.

- **Time Complexity: O(1)** (after finding the node)

**4. Insert At End**

- Traverse to the last node.

- Point the last node’s next to the new node.

- **Time Complexity: O(n)**

**5. Delete Node (by value)**

- Find the node (and its previous node).

- Update previous node’s next to skip the deleted node.

- Free the deleted node.

- **Time Complexity: O(n)**

**6. Delete First Node**

- Update head to the second node.

- Free the old head.

- **Time Complexity: O(1)**

**7. Delete Last Node**

- Traverse to the second-to-last node.

- Set its next to NULL.

- Free the last node.

- **Time Complexity: O(n)**