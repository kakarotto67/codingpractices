# Coding Practices
Contains generic small projects related to Algorithms, Patterns, etc.


## Top 10 Algorithms
### 1. Depth First Search (DFS) on tree/graph
#### Problems to solve
- Find min/max
- Find specific element
- Traverse all elements (e.g., to print them out)

#### Solution
- Use a Stack to solve the problem (recursive call-stack)

#### Complexity
- Search complexity is O(log n) for balanced tree

### 2. Breadth First Serach (BFS) on tree/graph
#### Problems to solve
- Find min/max
- Find specific element
- Traverse all elements (e.g., to print them out)

#### Solution
- Use Queue to solve the problem

#### Complexity
- Search complexity is O(log n) for balanced tree

### 3. Matchin Parenthesis Problem 
#### Problems to solve
- Check if all opening or left hand parenthesis have a closing or right hand parenthesis

#### Solution
- Use a Stack to solve the problem

#### Complexity
- Check complexity is O(n)

### 4. Using Hash Tables
#### Problems to solve
- Storing key/value pairs
- Fast lookup

#### Solution
- Use has function that produces an internal hash key of fixed size for any input key of arbitrary size
- Use algorithms like SHA 256 to generate a hash

#### Complexity
- Search complexity is O(1)

### 5. Variables/Pointers Manipulations
#### General information
- C#'s value types (your work directly with values stored in Thread's stack)
- C#'s reference types (you work with references stored in Thread's stack but actual instances stored in AppDomain's heap)

### 6. Using Linked List
#### Problems to solve
- Find/remove duplicates
- Reverse linked list

#### Solution
- Use while loop to update references between nodes to reverse a list [implementation] (https://github.com/kakarotto67/codingpractices/tree/master/ArraysAndLists/LinkedList)

#### Complexity
- Reverse complexity is O(n)

### 7. Sorting Algorithms
#### Problems to solve
- Sort arras, list and other collections

#### Solution
- Selection sort
- Insertion Sort
- Bubble Sort
- Quick Sort

#### Complexity
- Quick Sort complexity is O(n * log n), for others - O(n2)

### 8. Recursion
#### Problems to solve
- Implement recursion-based algorithms

#### Solution
- Nested call of same method with exit condition to prevent stack overflow exception

#### Complexity
- Typically recursion-based algorithms have O(log n) complexity

### 9. Custom Data Structures (OOP)
#### General information
- Use OOP to design custom data structures
- Use inheritance/decorator/extensions techniques to extend existing data structures
- Use polymorphism/strategy/state techniques to change data structures behavior
- Follow SOLID principles
 
 ### 10. Binary Search
 #### Problems to solve
 - Find element in sorted array
 
 #### Solution
 - Check the mid element and recursively divide the search interval in half by comparing searched value with the mid value
 
 #### Complexity
 - Lookup complexity is O(log n)
