---

# .NET

---

## Library vs Framework vs Platform

### Library

- **Definition**: A collection of pre-written code (functions, classes, modules) that helps developers perform common tasks without writing everything from scratch.

- **Control**: You call the library → the developer is in control and decides when/where to use the library’s code.

- **Example**:

    -C++ Standard Template Library (STL) → vectors, maps, algorithms.

    -JavaScript’s jQuery → DOM manipulation.

### Framework

- **Definition**: A collection of libraries and tools that provides a skeleton or structure for building applications. It enforces certain rules, patterns, and flow.

    A framework defines a set of rules, protocols, and conventions that developers must follow when writing their code. This helps ensure that all parts of an application work well together and follow a consistent design pattern.

- **Control**: The framework calls your code → known as Inversion of Control (Hollywood Principle: “Don’t call us, we’ll call you”).

- **Example**:

    - Angular → web development framework.

    - Django, Ruby on Rails → back-end frameworks.

### Platform

- **Definition**: A runtime environment (hardware + operating system + libraries + tools) where applications run. It provides the base on which software can be developed and executed.

- **Formula (simplified)**:

    `Platform = Operating System + Programming Language + Libraries + Tools`

- **Example**:

    - Windows, Linux, macOS (hardware + OS platforms).

    - Java Platform (JVM + Java language + standard libraries).

    - Node.js Platform (V8 engine + JavaScript + APIs).

---

## .NET

### What is .NET?

- **.NET** is a **software development platform** created by Microsoft.

- It provides a **runtime environment**, **programming languages**, and a **standard set of libraries** for building and running applications.

- With .NET you can build:

    - **Web apps** (ASP.NET, Blazor)

    - **Desktop apps** (WPF, WinForms, UWP, MAUI)

    - **Mobile apps** (Xamarin, .NET MAUI)

    - **Cloud apps** (Azure integration)

    - **Games** (Unity uses C# on .NET)

    - **IoT apps** (devices, sensors)

    - **AI & Machine Learning** (ML.NET)

### Who Built .NET?

- Originally developed by **Microsoft** (first release in 2002).

- Today, **over 100,000 developers and thousands of companies contribute** to .NET as an **open-source project**.

- Managed under the **.NET Foundation**.

### Components of .NET Platform

- **Languages** – C#, Visual Basic, F#, etc.

- **Runtime** – The environment that executes .NET code.

- **Base Class Library (BCL)** – Common APIs for collections, file I/O, networking, threading, etc.

- **App Models** – Frameworks for specific app types (ASP.NET for web, WPF for desktop, Xamarin for mobile, etc.).

- **.NET Standard** – A set of common APIs shared across all .NET implementations → ensures code/libraries work everywhere.


### .NET Implementations

Think of .NET as a **platform family** with multiple members:

- **.NET Framework**

    - Oldest version (2002).

    - Windows-only.

    - Used for **desktop apps**, **Windows services**, and **classic ASP.NET web apps**.

    - Mature but **not cross-platform**.

- **.NET Core**

    - Introduced in 2016.

    - **Cross-platform** (runs on Windows, Linux, macOS).

    - Modular, lightweight, and optimized for **cloud and modern apps**.

    - Eventually merged into **.NET 5+ (modern unified .NET)**.

- **Xamarin / Mono**

    - Used for **mobile development** (Android, iOS).

    - Based on Mono, an open-source .NET implementation.

    - Evolving into **.NET MAUI** (multi-platform UI).

- **.NET 5, 6, 7, 8… (Modern .NET)**

    - From **.NET 5 (2020)** onwards, Microsoft unified .NET Core, Xamarin, and .NET Framework into a **single product called just ".NET"**.

    - Example: **.NET 8** (latest LTS) is used for web, desktop, mobile, and cloud—all in one platform.

### .NET Standard

- **A specification of common APIs** across all .NET implementations.

- Purpose: so libraries written for .NET Standard can run on **.NET Framework**, **.NET Core**, and **Xamarin** without modification.

- Today, .NET 5+ has largely replaced the need for .NET Standard, since everything is unified.

---

## Compilation in .NET

When you write a .NET program (C#, F#, VB.NET):

**1. Source Code → IL (Intermediate Language)**

- Your code is first compiled into **CIL (Common Intermediate Language)**, also called **MSIL (Microsoft Intermediate Language)**.

- This IL is platform-agnostic (not tied to Windows, Linux, ARM, etc.).

- The compiled IL is stored in **assemblies** → files with .dll (library) or .exe (executable).

**2. IL → Machine Code**

- At runtime, the **CLR (Common Language Runtime)** executes the IL by compiling it into machine-specific instructions.

- This is done through **JIT (Just-In-Time)** or **AOT (Ahead-Of-Time)** compilation.


### JIT Compilation (Just-In-Time)

- **When**: Happens at runtime.

- **How**: CLR compiles only the methods that are being used → on-demand.

- **Pros**:

    - Fast startup (since not all code is compiled immediately).

    - Adapts to the specific hardware of the machine.

- **Cons**:

    - May cause small delays during execution (when new methods are compiled).

**Example**: When you run a .NET app on Windows, JIT compiles IL into x86/x64 instructions specific to your CPU.

### AOT Compilation (Ahead-Of-Time)

- **When**: Happens before runtime (pre-compilation).

- **How**: IL is compiled into **native machine code** ahead of time.

- **Tools**:

    - **Ngen.exe** (Native Image Generator, used in classic .NET Framework).

    - **Crossgen / Crossgen2** in .NET Core / .NET 5+.

    - **ReadyToRun (R2R)** and **Native AOT** (in modern .NET).

- **Pros**:

    - Faster startup (no JIT needed).

    - Optimized for specific hardware (CPU instruction sets, SIMD, etc.).

    - Great for mobile/embedded/cloud environments where startup time matters.

- **Cons**:

    - Larger file size (since native code is embedded).

    - Less flexible than JIT (harder to adapt dynamically to different environments).

**Example**: Xamarin/MAUI apps for iOS use AOT by default since Apple doesn’t allow JIT on iOS devices.

---

## .NET Framework

### .NET Framework Architecture

The **.NET** Framework has **3 main parts**:

**1. Languages**

- Examples: **C#, Visual Basic, F#**.

- Code written in these languages is compiled into **CIL (Common Intermediate Language)**.

- Thanks to the **Common Type System (CTS)** and **Common Language Specification (CLS)**, all .NET languages can interoperate (e.g., you can write a class in C# and use it in VB.NET).

**2. Common Language Runtime (CLR)**

The **heart of the .NET Framework**. It is the execution engine responsible for running .NET applications.

**Key responsibilities of CLR:**

- **Memory management** → automatic garbage collection.

- **Thread management** → manages multithreading and parallel execution.

- **Exception handling** → unified error handling across languages.

- **Type safety & security** → ensures code doesn’t access invalid memory.

- **JIT Compilation** → compiles IL into machine code at runtime.

- **Interoperability** → allows .NET code to interact with COM and native code.

**3. .NET Framework Class Library (FCL / BCL)**

- A large collection of **pre-built reusable classes and APIs**.

- Provides common functionality:

    - **System.IO** → file handling.

    - **System.Data** → database access (ADO.NET).

    - **System.Net** → networking, HTTP.

    - **System.Drawing** → graphics.

    - **System.Windows.Forms / WPF** → desktop UI.

    - **ASP.NET** → web applications.

### Version Info

- The **latest .NET Framework version = 4.8.1** (released 2022, Windows-only, stable but not evolving further).

- The **latest unified .NET version** = **.NET 9.0** (2024, cross-platform, successor to .NET Core).

---

## CLR

### Why CLR is Powerful?

- You can write code in different .NET languages (C#, VB.NET, F#), but thanks to CLR:

    - They all compile to the **same IL code**.

    - They all run under the **same runtime environment**.

    - They can interoperate seamlessly (e.g., a C# class can be used in VB.NET).

### Analogy

- CLR is like a **universal translator in real life**:

    - People (languages like C#, VB.NET, F#) speak different languages.

    - The translator (CLR) converts everything into one common understandable form (IL → Machine Code).

    - The audience (computer hardware/OS) receives the final translated version (native code).

- In essence, the CLR acts as a bridge between the .NET code and the underlying operating system, allowing .NET code to run on any supported platform. 

- This allows .NET developers to write code in any .NET-supported language and have it run on any supported operating system, without having to worry about the underlying hardware and software details.

---

## CLR Main Components

- Common type system (CTS)

- Common language speciation

- Garbage Collector

- Just in Time Compiler

- Metadata and Assemblies

---

## Common Type System (CTS)

The Common Type System (CTS) is a set of rules that describes how types are declared, used, and managed in the .NET runtime.

### Purpose:

- Ensures **type safety** across different .NET languages (C#, VB.NET, F#, etc.).

- Allows **cross-language interoperability** (code written in one .NET language can work with another).

- Standardizes how data types are represented at runtime.

### Key Features of CTS:

- Type Safety:

    Prevents invalid type conversions (e.g., converting a string directly to an int without parsing).

- Language Interoperability:

    Example:

    - C# → int

    - VB.NET → Integer

    - After compilation, both become System.Int32 in IL (Intermediate Language).

- Two Categories of Types:

    - **Value Types** (stored directly on the stack) → e.g., `int`, `float`, `bool`, `struct`.

    - **Reference Types** (stored on the heap with a reference on the stack) → e.g., `class`, `interface`, `string`, `object`.

---

## Common Language Specification (CLS)

The **CLS** is essentially a **set of rules or standards** that all .NET languages must follow to ensure they can work together seamlessly. Think of it as a “universal contract” for .NET languages.

### Key Points:

- **Purpose of CLS**

    - Ensures **interoperability** between .NET languages (like C#, VB.NET, F#).

    - Makes it possible for code written in one language to **inherit**, **use**, or **call** code written in another .NET language.

    - Facilitates **cross-language debugging** and maintenance.

- **What CLS Does**

    - Defines a **common set of types**, **naming conventions**, and **programming constructs** that all languages **must support**.

    - Prevents language-specific features that **cannot be understood by other languages** from **breaking compatibility**.

- **Example**:

    - C# has `sbyte` (signed byte), but VB.NET doesn’t. If you expose `sbyte` in a public API, other languages may not be able to use it. CLS rules would recommend using `byte` instead, which is CLS-compliant.

- **CLS-Compliant Code**

    - To make your code CLS-compliant, you can use the `[CLSCompliant(true)]` attribute in .NET.

    - This tells the compiler and other developers that your code **follows CLS rules** and is safe for cross-language use.

- **Benefits**

    - **Language integration**: Different languages can interact smoothly.

    - **Code reusability**: Libraries written in one language can be used in another.

    - **Consistency**: Reduces bugs and issues from language-specific limitations.

---

## Garbage Collector (GC)

The **Garbage Collector** is a **built-in memory management system** in the **CLR**. Its main job is to **automatically manage the allocation and deallocation of memory for objects**.


### Key Responsibilities:

- **Automatic Memory Allocation**

    - When you create an object in .NET, the GC **allocates memory for it on the heap**.

    - You don’t need to manually manage memory like in C++ (no `new`/`delete` worries for heap objects).

- **Automatic Memory Reclamation**

    - When objects are **no longer in use** (i.e., there are no references pointing to them), the GC **frees the memory** so it can be reused.

    - This prevents **memory leaks** and **improves the efficiency of your application**.

- **Object Safety**

    - GC ensures **one object cannot overwrite or access another object’s memory**, which prevents many runtime errors.

- **Generations in GC**

    - .NET GC uses a **generational approach** to improve performance:

        - **Generation 0**: Newly created objects (short-lived).

        - **Generation 1**: Objects that survived one GC cycle.

        - **Generation 2**: Long-lived objects (e.g., large data structures).

    - This approach reduces the cost of memory management by focusing on cleaning up short-lived objects more frequently.

- **Why GC Matters**

    - Simplifies programming: Developers **don’t have to manually free memory**.

    - Prevents common memory errors like dangling pointers or double deletion.

    - Helps maintain overall application stability and performance.

---

## Just In Time Compilation (JIT)

The JIT Compiler is a core component of the **CLR**. Its main role is to **convert MSIL (Microsoft Intermediate Language) into native machine code** that the computer’s processor can execute.


### Types of JIT Compilers

**1. Pre-JIT (Ahead-of-Time, AOT)**

- Compiles the **entire MSIL code into native code before execution**.

- **No runtime compilation** is required.

- Tool: **Ngen.exe** (Native Image Generator).

- Advantage: **Faster runtime execution**.

- Use case: Applications where startup performance is critical.

**2. Econo-JIT**

- Compiles **only the parts of MSIL that are needed at runtime**.

- **Does not cache** compiled code; recompiles if used again.

- Advantage: **Saves memory**.

- Drawback: Recompilation overhead if same code is used multiple times.

**3. Normal JIT (Default)**

- Compiles **only the MSIL code that is required at runtime**.

- **Caches the compiled code** for future use.

- Advantage: **Balances memory usage and performance**.

- Default option in most .NET applications.

### Key Points

- JIT compilation allows .NET to be **platform-independent** at first (MSIL), yet **optimized for a specific machine at runtime**.

- It reduces the need to precompile all code (except Pre-JIT).

- By caching compiled code (Normal JIT), repeated executions are faster.

---

## Assemblies & Metadata(Manifest)

### Assemblies

An **assembly** is the **fundamental unit of deployment and execution in .NET**. It is a **compiled chunk of code** that the **CLR can execute**. Think of it as a container for code, resources, and metadata.

### Key Points:

- **Purpose**

    - Provides a **unit of deployment** for .NET applications.

    - Can be executed by the CLR.

    - Ensures that all code, resources, and metadata required are packaged together.

- **Types of Assemblies**

    - **Executable (.exe)**: Can be run directly by the operating system.

    - **Dynamic Link Library (.dll)**: Cannot run by itself; it’s used as a library by other programs.

- **Advantages**

    - Modular code organization.

    - Version control for easy maintenance.

    - Reusable code across multiple projects.

### Metadata (Manifest)

**Metadata**, also called a **manifest**, is **data about data** in .NET assemblies. It provides the CLR with all the information it needs to execute the program and manage the assembly.

**Metadata Contains:**

**1. Assembly Information**

- Assembly’s **name**

- **Version number**

- **Digital signature** identifying the creator

**2. File Information**

- List of all files that make up the assembly

**3. Referenced Assemblies**

- Information about other assemblies used by this assembly

**4. Type Information**

- Details about all exported classes, methods, properties, and other members

---

## CLR Functions

### Key Functions of CLR:

**1. Converts Program into Native Code**

CLR uses the **JIT** compiler to convert MSIL into **machine-specific native code** that the processor can execute.

**2. Memory Management**

- Automatically manages memory allocation and deallocation.

- Uses the **Garbage Collector (GC)** to clean up unused objects.

**3. Handles Exceptions**

- Provides a **robust exception-handling mechanism** to catch and manage runtime errors.

**4. Provides Type-Safety**

- Ensures that objects are used only according to their declared types.

- Prevents unsafe type conversions and memory access errors.

**5. Provides Security**

- Enforces **code access security and role-based security** to protect applications.

- Prevents malicious code from performing unauthorized operations.

**6. Improves Performance**

- Optimizes code execution using JIT compilation, caching, and memory management.

**7. Language-Independent**

- Supports multiple .NET languages (C#, VB.NET, F#, etc.) by enforcing CLS rules.

**8. Platform-Independent**

- MSIL is platform-neutral, so the same assembly can run on any machine with a compatible CLR.

**9. Supports Object-Oriented Features**

- Provides built-in support for inheritance, interfaces, overloading, and other OOP features.

**10. Manages .NET Languages**

- Acts as the runtime manager for all .NET-supported languages, ensuring smooth execution and interoperability.

---

## Managed vs Unmanaged Code

### Managed Code

- **Definition**:

    Managed code is code that runs **under the control of the CLR**. It is written using **.NET languages** like C#, VB.NET, or F#.

- The CLR also provides an Interoperability layer, which allows both the managed and unmanaged codes to interoperate.

- Any language that is written in the .NET framework is managed code. Managed code use CLR, which looks after your applications by managing memory, handling security, allowing cross-language debugging, etc.

### Unmanaged Code

- **Definition**:

    Unmanaged code is code that **runs outside the control of the CLR**. It is usually compiled directly to machine code.

- Applications that do not run under the control of the CLR are said to be unmanaged. Certain languages such as C++ can be used to write such applications, such as low-level access functions of the operating system. 

- Background compatibility with VB, ASP, and COM are examples of unmanaged code. This code is executed with the help of wrapper classes.


**COM (Component Object Model):**

COM is an **old Microsoft technology (1993)** for client-server communication.

Allows applications to call methods from other applications **without compiling them together**.

Commonly used as a bridge between unmanaged and managed code.

---

## CLR Structure

### Components of CLR

**1. Base Class Library (BCL)**

- Provides a **collection of reusable classes, interfaces, and value types**.

- Supports common functions like file I/O, string manipulation, collections, and more.

- Example: `System.String`, `System.Collections.Generic.List<T>`.

**2. Thread Support**

- Manages **parallel execution of multiple threads** in a multi-threaded application.

- Ensures threads are scheduled properly and resources are shared safely.

**3. COM Marshaler**

- Provides **communication between COM objects and .NET applications**.

- Helps managed code interact with legacy unmanaged components.

**4. Security Engine**

- Enforces **security restrictions** at runtime.

- Implements **code access security** and **role-based security**.

**5. Debug Engine**

- Enables **debugging** of **.NET applications**.

- Works with Visual Studio to set breakpoints, watch variables, and step through code.

**6. Type Checker**

- Verifies that all data types used in the application **match the CLR rules**.

- Ensures **type safety**, preventing **unsafe conversions** and **memory access errors**.

**7. Code Manager (or Execution Engine)**

- **Manages execution of code at runtime**, including JIT compilation and code optimization.

**8. Garbage Collector (GC)**

- Automatically reclaims memory from objects no longer in use.

- Prevents memory leaks and ensures efficient memory allocation for new objects.

**9. Exception Manager (Exception Handler)**

- Handles runtime exceptions to prevent application crashes.

- Works with structured exception handling in .NET (try/catch/finally).

**10. Class Loader**

- Loads classes at runtime from assemblies into memory.

Ensures all referenced types are available for execution.

**11. IL Compilers (JIT Compiler)**

- Converts MSIL (Intermediate Language) into native machine code just before execution.

- Supports various types of JIT compilation: Pre-JIT, Econo-JIT, and Normal JIT.

---

## .NET Framework Class Library (FCL)

**The .NET Framework Class Library (FCL) is a comprehensive collection of reusable classes, interfaces, and value types** that developers use to build .NET applications. It provides all the building blocks needed for application development across different domains.


### Key Features of FCL

**1. Base and User-Defined Data Types**

- Supports **primitive types** (e.g., integers, strings) and allows creation of **custom classes and structures**.

**2. Support for Exception Handling**

- Provides **classes and methods** for managing runtime errors (`try`, `catch`, `finally`).

**3. Input/Output and Stream Operations**

- Offers classes for **file handling, reading/writing streams, and serialization**.

- Example: `System.IO.File`, `System.IO.StreamReader`, `System.IO.StreamWriter`.

**4. Communications with the Underlying System**

- Enables interaction with **operating system resources**, such as environment variables, processes, and event logs.

- Example: `System.Environment`, `System.Diagnostics.Process`.

**5. Access to Data**

- Provides classes for **database access, data manipulation, and LINQ queries**.

- Example: System.Data.SqlClient, System.Data.DataSet, System.Linq.Enumerable.

**6. Ability to Create Windows-Based GUI Applications**

- Supports building **desktop applications** with forms, controls, and event handling.

- Example: `System.Windows.Forms`, `System.Drawing`.

**7. Ability to Create Web-Client and Server Applications**

- Supports **web applications and networked clients, including HTTP requests and server responses**.

- Example: `System.Net.WebClient`, `System.Web`.

**8. Support for Creating Web Services**

- Provides classes to create and consume **XML-based or SOAP web services**.

- Example: `System.Web.Services`, `System.ServiceModel` (for WCF).

---

## What is C#? and Why to Learn It?

**C# (pronounced “C sharp”)** is a **general-purpose, object-oriented programming language** developed by Microsoft. It is part of the **.NET ecosystem** and is widely used for building a variety of applications.

### Key Features of C#:

**1. Modern and Powerful**

- C# is designed to be a **modern language**, following current programming trends.

- Allows developers to **build robust applications quickly and efficiently**.

**2. Simple and Readable**

- Syntax is **easy to understand** and very similar to **Java**, making it approachable for developers familiar with C-based languages.

- Helps in writing clean and maintainable code.

**3. Type-Safe**

- Ensures that variables are used **only according to their declared type**, preventing many runtime errors.

**4. Object-Oriented**

- Fully supports **OOP principles** such as:

    - **Objects & Classes**

    - **Inheritance**

    - **Polymorphism**

    - **Encapsulation**

**5. High-Level Language**

- Provides **abstraction from low-level memory management**.

- Focuses on application logic rather than hardware-level details.

**6. Community and Support**

- C# has a **large global community**, so questions, libraries, and learning resources are readily available.

### History

- First version released: 2002

- Latest version: C# 14, released November 2024

- Upcoming Version: C# 15

    Expected to release with .NET 10 in November 2025.


### Why is it called C#?

- The name comes from **musical notation**:

    - The **“#” (sharp)** symbol means the note is a **semitone higher**.

    - Symbolically, C# is seen as an **enhanced or improved version of C**.

### What Can We Do with C#?

Being part of the .NET ecosystem, anything you can do with .NET, you can do with C#

