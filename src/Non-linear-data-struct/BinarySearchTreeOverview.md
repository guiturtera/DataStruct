# Binary Search Tree (BST) - [Overview]
As shown in the code example, a BinarySearchTree is useful for some aplications that require specific performance.
A simple BinarySearchTree is not recommended, due to it's unpredictability.
As a solution, some new ways to work with it were invented. We'll see some of them.
## We'll see:
- AVL Tree
- Red-Black Tree
- Splay Tree
- There are some others, such as ScapeGoatTree, that we'll not be covering in this topic.

# AVL Tree (Height Balanced Tree)
	Invented in 1962 by G.M. Adelson-Velsky and E.M. Landis, AVL trees are used until today due to it's search efficiency.
	As his name says, this tree must have a controlled height, in order to standardize search operation.
	The Height of the left tree can differ by 1, 0 or -1 of the right one. This means that the tree will ALWAYS be (HeightLeft >= 0 && HeightRight == Abs((HeightRight - HeightLeft))
	The benefits of doing that, are as said before, a standardized O(logN) time for search.
	Although search method is greater in this tree, we will have the disadvantage of Insertion and Deletion methods.
- ## Methods
    - ### Insert and Delete
    	Insert and Delete methods will assure the proportional height of tree.
    	It can perform 4 types of operations, which are:
    	- LL (Left Left Method)
    	- RR (Right Right Method)
    	- LR (Left Right Method)
    	- RL (Right Left Method)
    - Other methods are the same as a normal BinarySearchTree
    - Benefits are that, if you need massive search for data, this tree will assure O(logN) in the WORST case.

# Red-Black Tree
    The Red-Black tree are also widely used due to it's self-balancing. 
    Its insertion and deletion methods will assure a proportional height <= 2 log2(n + 1)
    All Search, Delete and Insert methods are O(logN)
    They are used most in cases that you need to change a lot of the data.
- ## Rules
    - Every node has a colour either red or black.
    - The root of the tree is always black.
    - There are no two adjacent red nodes (A red node cannot have a red parent or red child).
    - Every path from a node to any of its descendants NULL nodes has the same number of black nodes.

# Splay Tree
    Splay trees can be used with other ones, such as AVL or Red-black.
    The concept of a Splay Tree is to always bring the most used data to near root locations, which can improve the performance in the average case. There are many pratical applications that can be used with it.
- ## Changing the Search Method
    There are used some methods to change the body of the tree.
    They are:
    - Zig
    - Zig-Zig and Zag-Zag
    - Zig-Zag and Zag-Zig
This methods will assure that the most recent and frequently used data to be found faster, near the better case O(N).

- # Observations
    - ### AVL Trees vs Red-Black Trees  
        They are both used, but with different purposes. To be pratical, use AVL Trees if you don't need to Insert and Delete data frequently, and a search efficiency (O(logN)).
        On the other hand, if you also need to Insert and Delete, Red-Black trees are a good option, because of it's 
        versatility. 
    - ### When to use Splay Trees?
        If you are using a Splay Tree, have in mind that you will be losing efficiency in the search time, and also earning some.
        That happens, because if your amount of data is short, or if you randomly select items, you'll lose efficiency implementing it. Although, if you have a big amount of data and a tendency to search for some specific data, it may improve your algorithm.

# Bibliografy
Book -> Data Structure using C, Reema Thareja
https://www.geeksforgeeks.org
