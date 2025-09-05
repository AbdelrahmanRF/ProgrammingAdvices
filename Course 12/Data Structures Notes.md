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

**1. Definition**

- **Data Structure**:

    A way to organize and store data in memory (RAM) for efficient processing during program execution.

    Examples: Arrays, Linked Lists, Stacks, Queues, Trees, Graphs, Hash Tables.

- **Database**:

    A system (usually software) used to store, manage, and retrieve large amounts of data permanently (on disk/storage).

    Examples: MySQL, Oracle, MongoDB, PostgreSQL.

<br>

**2. Purpose**

- **Data Structure**: Focuses on efficient access, modification, and processing of data while the program is running.

- **Database**: Focuses on persistent storage, querying, and management of data even after the program stops running.

<br>

**3. Storage**

- **Data Structure**: Data is usually stored in memory (RAM) → temporary, fast access.

- **Database**: Data is stored on disk or cloud storage → permanent, can survive power loss.

<br>

**4. Scale**

- **Data Structure**: Works with data that fits in memory, usually for program-level operations.

- **Database**: Works with huge datasets, often involving millions of records and multiple users.

<br>

**5. Operations**

- **Data Structure**: Searching, sorting, insertion, deletion, traversal.

- **Database**: CRUD operations (Create, Read, Update, Delete) using query languages (like SQL).

<br>

**6. Examples in Use**

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

**1. Primitive (Basic) Data Structures**

- Examples:

    **Integer**

    **Float / Double**

    **Character**

   **Boolean**

**2. Non-Primitive (Advanced) Data Structures**

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