# SimpleTopDownShopGame

A simple top-down game that has been developed to serve as an example for code organization and file structuring. 

The game's scenes are organized, ensuring a clear separation between the player, the map, and the user interface (UI). This separation eliminates any direct references between elements in different scenes. As a result, the player and UI scenes can be easily repurposed by simply swapping out the map scene.

To maintain a clean and efficient codebase, the game utilizes Scriptable Objects to manage the player's state and inventory. These Scriptable Objects serve as central repositories and are exclusively accessed by the Inventory and Shop Managers, ensuring encapsulation and modularity.

Furthermore, Scriptable Objects are employed as data classes to streamline the inventory, shop, and item management systems. This approach promotes a consistent and organized structure within the codebase, simplifying maintenance and future expansions.

The game also features an abstract class that serves as a foundation for the shopkeeper NPC. By utilizing inheritance, this abstract class can be extended and implemented by other classes with diverse purposes, requiring only the implementation of the Interact function. This allows for code reuse and flexibility, enhancing development efficiency.

While acknowledging that there is room for improvement, certain aspects of the code were not optimized due to time constraints. For example, updating the player's graphics when a new item is equipped could benefit from event listeners. Additionally, the responsibility of triggering interactions has been assigned to the player, utilizing a raycast to detect and call the Interact function on the appropriate GameObject.