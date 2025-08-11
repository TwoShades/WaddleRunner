# Waddle Runner - A Mobile Game made with Unity

## Overview -

- Waddle Runner is a full fledge game around a penfuin who runs around to capture fishes, and uses these to buy cool looking hats.
- Things I have learned in the making of this project includes: Game Architecture, Design Patterns, and much more.

### Tools used during the making of this project include:

- Universal Render Pipeline
- Mechanim animator
- Input System
- State Machine
- CineMachine
- Serialize Saving

### Assets used in this project can be found here: 
https://gitlab.com/MichaelDoyon/epitomegames/-/blob/master/SubwaySkater2020.unitypackage 


## Visuals & Artists tools
First things first, create a new Unity project by selecting the "3D Sample Scene (URP)". If this cannot be found, try installing an earlier version of the Unity engine such as the one I used to make this project (2019.4.40f1).

Then we'll go ahead and delete a few files and folders from the Sample we just created.
- Delete "ExampleAssets"
- Delete "Materials"
- Delete "Presets"
- Delete "Scene" **But keep the folder**
- Delete "Scripts" **But keep the folder**
- Delete "Settings" **But keep the folder**
- Delete "TutorialInfo"
- Delete "Readme"

Hit CTRL + N to create a new Scene or click the File menu and select "New Scene". Unity will ask you if you want to save the current scene, you can go ahead and say no. Now that we are in our new Scene, hit CTRL + S to save the new scene or click the File menu and select "Save". Save it as "Game" to make it easy to understand. You will now see a "Scene" called "Game" in the Project folder. Drag and drop it into the "Scene" folder that we emptied earlier.

### Universal Render Pipeline

Click on the Window menu and select "Package Manager". A new window will appear and **make sure** that the "All packages" or "Unity Registry" is selected at the top left of this window. Search for Universal RP, select it and install it.

In the Project folder, Right-Click on the "Settings" folder and hover on "Create", then hover on "Rendering", then hover on "Universal Render Pipeline" and select "Pipeline Asset (Forward Renderer)". You can leave the default name for this one. Now you'll see two (2) new assets and to make sure that our project actually uses these, we'll go in the Edit menu and select "Project settings", then select the "Graphics" tab on the left pane and finally Drag and Drop our new Pipeline Asset in the "Scriptable Render Pipeline Settings". **Make sure** to drag the "UniversalRenderPipelineAsset" instead of the "UniversalRenderPipelineAsset_Renderer"

### 3D Assets

Once we have downloaded the Assets mentioned above, just go ahead and Double-click the Package file. It will automatically import it to your open Project. To make sure you have everything you need, Unity will display a new window for you to select or deselect any assets from the package. Once you made sure that all the assets are selected, click "Import". You should now have a few folder installed in the Project such as "Artwork" which contains: _PSD, Material, Models, Sky. You will notice that all the assets are showing up gray as you take them into the Game scene. This is because the assets do not have a Material texture added to them, we can go ahead and do that on our Main character. The penguin can be found under Assets/Models/Penguin. Just drag and drop the Penguin in the Hierarchy window or the Scene window. Now open the "Material" folder and drag and drop the "Atlas" texture onto the Penguin. Now we have a pink Penguin and that is because the shader is not found. We'll fix this by having the "Atlas" texture selected and going in the "Inspector" window on the right. We will work on this later but for now, we can go and change the Shader to "Universal Render Pipeline" and select "Lit". Our Penguin is back to gray, now we'll include a "Base Map" found in the inspector. A new "Select Texture" window will appear and all we need to do is select the "AtlasTexture".

### Animations

We can find our animations under Assets/Artwork/Models/Penguin and they are called by their own names "Death", "Idle", "Jump" "Run" and "Slide". We can also see the "PenguinAnimator", **make sure** to have the Penguin selected in the Hierarchy window and then simply drag and drop the "PenguinAnimator" in the Inspector window. For the purpose of this project, the animator was already created BUT we will play around and make our own animator to understand what is happening. If you want to make one from scratch I invite you to either disregard the previous point or to simply remove the pre-made animator from the Penguin. Now in the Inspector window (having selected the Penguin in the Hierarchy window) click the "Add Component" button and search for "Animator" then add the component to the Penguin. Now let's Right-click the Penguin folder in the Project window, hover on Create and select the "Animator Controller". In this case we can name it "PenguinAnimator2.0". To open the Animator window, simply double-click it OR open the Window menu, hover on "Animation" and select "Animator". You will see 3 "button" shaped components in there: "Entry", "Any State" and "Exit". The "Entry" means every time you press on Play, the "Exit" if you wish for your animation state machine to end at one point, and "Any State" which will make a transition FROM any state (as long as the conditions are met) to whatever state is attached to it.

Let's create a new state by Right-clicking anywhere in the animator, hover on "Create State" and select "Empty". You can rename this new Empty animation in the Inspector window, let's call it "Idle". A cool thing we can do with the Animator is to receive a Live Link from the game to the animator, that means that if I have an object in the game that uses this animator I will be able to see the transitions in the animator as they happen. For that we'll select the Penguin from the Hierarchy window and look for the "Controller" in the Animator component, simply click the button on the right side of it where it currently says "None (Runtime Anim...)" and select our new "PenguinAnimator2.0". Now that we have this one selected, let's go ahead and play the game. We can see that the animator window now shows "Idle" being used and also looped over and over again. **Keep in mind that if you want to see the object in action and where it is in the flow, you have to select that object in the Hierarchy window**. The "Idle" state is currently being used, but it is just a state for the moment, there is no animation attached to it just yet. Select the "Idle" state in the Animator window and go to the Inspector window, look for "Motion" and change it to the "Idle" animation. Now our Penguin is moving with the "Idle" animation! Let's go through the loop and create another state that we'll call "Running". You'll notice that our "Idle" state was created with a transition from "Entry" but the new "Running" state has no link to anything. We'll simply Right-click on "Idle" and select "Make Transition" then click on the destination. Now our player should go in Idle state when we press play and once the Idle animation is finished it will transition to the Running state. Again **make sure** to select Running state and change the Motion in the Inspector window to the Run animation. If we select the transition "line" from Idle to Running, we'll see in the Inspector window that we can change some parameters. We want to have a "Condition" to the Running state otherwise the player will constantly be running. Click on the "+" button in the Conditions parameter and we'll get the "Parameter does not exist" message. Back to the animator window, on the top left you'll see two "Tabs" one Layer and the other Parameters, head over to the Parameters. Unfortunately we cannot add new parameters while the game is playing so select the play button at the top to stop the game. Then we'll select the "+" button to add a new parameter, select the Float option and rename it to "Speed". Head back to the Inspector window and add our new condition. We can say, is "Speed" "Greater than" "1" for example. To test this condition without having to go through some code, we can simply hit Play and see that the player is in a "Idle" loop. Change the value in the Animator window to anything more than 1 and hit enter. Now the player has started to Run. Something subtle that we have to look at here is, once you input (number higher than 1) as the speed, the Idle state "has" to finish it's animation before moving to the other state. Obviously we don't want that so this is what we're gonna do. Select the transition line between Idle and Running in the animator window and look at the Inspector, there is a Bool parameter called "Has Exit Time" turn this one off. Now press play and see the difference when you input (number higher than 1) to the speed.

Next thing we will play with is the "Any State". Create a new state and call it "Jump", Right-click "Any State" and create a transition to Jump. Now we have to create a new "Trigger" parameter called "Jump" and **don't forget** to set the condition in the inspector while having the transition line selected. Also **don't forget** to set "Motion" to Jump in the inspector. With that in mind, go ahead and create all of the states we'll be using (Death, Slide, Falling, Respawn). Every one of these states has their own Motion except the Respawn state which we'll use the Jump Motion. Now make a transition line between Any State and all the new states we just created. We also need to make all of the parameters for conditions: Slide(Trigger), Running(Trigger), Respawn(Trigger), Death(Trigger), Fall(Trigger), and finally we'll create one with a Boolean called "IsGrounded". **Make sure** to put all the conditions to the transitions. Now let's make a new transition from "Jump" to "Running", "Slide" to "Running", "Respawn" to "Running". The condition for Slide to Run should be "Running", from Respawn to Run should be "IsGrounded" = "true", and Jump to Run should also be "IsGrounded" = "true". **Make sure** to toggle off every transition's "Has Exit Time". 

## Creating a small environment

This is not a "needed" part but it is going to be convenient for us soon since we're going to be playing around with the Universal Render Pipeline and also the lighting of the game. In the Hierarchy window, Right-click and hover on "3D Object" then select the "Plane" object. Place it at the center of the world by (having it selected in the hierarchy window) putting the "Position" X, Y, and Z values to 0 in the inspector window. Go ahead and rename that object to "Floor" to make it easier. Let's take out a few models from the Project window, we can use mainly the ones in the "Environment" folder since we won't be using them for anything else than that really. **Keep in mind** that the player will be running forward on the Z axis so place your environment objects accordingly. We will also need to Drag and Drop the "AtlasTexture" found in Assets/Models/Environment/Materials to all of the objects we just placed. **Don't forget** to set the "Base Map" of the texture in the inspector window. **ALSO**, before we move on from here, let's take the "Snow" material found in Assets/Artwork/Material and drag this one to our "Floor" plane. It will be pink since we didn't allocate anything to this texture yet. Same as before we'll use the Universal Render Pipeline -> Lit, then for the Base Map we'll search for the "Snow" texture and apply it.

## URP & Light Settings

In the project window, head over to the "Settings" folder and click on the "UniversalRenderPipelineAsset" that we created earlier. We will see in the Inspector window that there is a lot of drop down menus. 
Under General, we'll keep most of the settings as they are. We'll just disable the "Terrain Holes" setting since it decreases build time and we won't be using it's function anyway.
Under Quality, leave HDR off. You can play around with the Anti Aliasing (MSAA) setting and decide for yourself if you want it or not, it is a good way to have a "clearer" image without spending too much resources. For mine, I left it Disabled. Also leave the Render Scale to 1.
Under Lighting, the "Main Light" is defined as the brightest directional light in the scene. We'll leave the Main Light setting at "Per Pixel" and we'll take a look at "Cast Shadows" you can toggle it on or off, if On you also have the "Shadow Resolution" setting which will define how many pixels per shadow. For the pupose of the project, I had it on for a while with Shadow Resolution at 512pixels and eventually decided to completely remove shadows.

Under Shadows, you can play around and see what settings you prefer but like I mentionned just above, I didn't end up using shadows at all for this project. If you do end up using it, I recommand having a lower resolution shadow (256 or 512) and toggle the "Soft Shadows" setting.

Under Post Processing, we'll leave everything as it is.
Under Advanced, we will also leave everything as it is except for the "Dynamic Batching" setting which we'll toggle on.

Now let's play around the lighting a bit. Click on the "Directional Light" in the Hierarchy window and look at the Inspector. In the "Light" tab we'll change the Color to a bright white, if you plan to use the shadows you can go ahead and play with the "Strenght" under Realtime Shadows, this will enable you to have softer or more opaque shadows.
Next we'll head over to the Skybox under Assets/Artwork/Sky, now let's look at how to create one exactly like this. Simply Right-click the "Sky" folder, hover on "Create" and select "Material". Change the Shader to Skybox and select "Procedural". Let's use the one we already have by dragging it into the sky!

## ShaderGraph

First let's create a new folder inside the Assets folder. Call it "Rendering". Right-click the new folder and hover on "Create", hover "Shader" and select PBR which stands for Physically Based Rendering. Call it "Main" for now, then Right-click the Rendering folder again and Create a new Material that we will name "Main". If we want to use the PBR we just created we'll have to attach it to our new Material and for that we just need to change the Shader to ShaderGraph -> Main. 

Now let's open up the PBR by double clicking on it, a new window will appear with the name "Main" and we can see our Master Node here. Click on the "+" button in the blackboard and create a new "Texture2D" property and call it "mainTexture". Now hit the spacebar in the middle of the screen and type "Sample Texture 2D" to create a sample of a normal texture. Now take the mainTexture and link it to the Texture of the Texture2D and link the RGBA of the Texture2D to the Albedo of our PBR Master. Which means that if we have the Main selected and go in the Inspector, change the mainTexture setting to the Atlas material we now have a functionning texture! **Also make sure to drag the Atlas texture from Assets/Artwork/_PSD to the "Default" of mainTexture in the blackboard.** 

## Tiling the shader

First thing we need to do is make sure all of the objects in the game have the same shader, we can either drag and drop the new shader to each item OR select the item, Right-click the Atlas Texture in the Inspector window, select the "Select Material" option and that's gonna take us to the material the object is using. To change the shader we'll simply change it to ShaderGraph -> Main. *If needed, drag and drop that same material to any objects that don't have a material on them*

Now let's do the same for our floor. Click on the Floor and Right-click the "Snow" component, then select "Select Material" and change the shader again to ShaderGraph -> Main. This time instead of using the Atlas as the main texture  we'll need to use the "Snow" texture. 

Back to the Shader (Main) window, we'll go ahead and hit spacebar to create a new parameter and look for the "Tiling and Offset". Link the output of this new node to the "UV(2)" input of the Sample Texture 2D. 

In the blackboard, create a new parameter "Vector1" and call it "tiling" drag and drop it out of the blackbox, link it to the "Tiling(2)" input of the Tiling and Offset. We can do the exact same thing for the offset. **Don't forget to Save Asset in the top left corner of that window to save what you are doing**. You might notice that everything is off now and that is because the parameter simply didn't save in the inspector. First put the default "tiling" in the blackboad to "1" and do the same in the inspector. Now the texture should be back to normal.

## Bending the world!

To bend the world really means, we'll make it look like it's bending. So the Shader is going to look like it's bending but the objects themselves are gonna remain at the position they were placed. To do that we'll hit spacebar and look for "Position", then spacebar again and look for "Add" and last one for now "Vector 3". In the Vector3, change the Y to "1".
Now link the "position" output to the "A(1)" of the "Add", also link the output of the Vector 3 to the "B(1)" of the Add and finaly the output of Add to the "Vector Position" of our PBR Master. Save the asset and you'll see that now all of the object's Y position has been incremented by 1.

That is something we will keep for a bit later so for now just change the value of "Y" to 0 so all the objects are not being incremented.

In the Scene window, let's duplicate the floor a couple times on the Z axis **Make sure to go forward by following the arrow of the object**. 

Back to the Main window, we'll actually delete the Vector 3 parameter for now because we will be replacing it with some arithmetic operations. Here we need to calculate something regarding the camera position and also the world position of the object. We'll need two new nodes, first will be Position (yes another one) and instead of using the object space, we will be using the absolute world. Second will be the "Camera" node. Let's take these nodes and Substract them by getting the "Subtract" node. We'll take the Camera position and remove the position of the Vertex so "Camera" "Position" should be linked to the "Subtract" "A(3)" and the "Position" output should be linked to the "B(3)" of the "Subtract". Now for our purpose, we only need to pass through the Z axis, we can do that by adding a "Split" node. Now link the "Subtract" output to the only input for "Split". You'll notice that the split's output are R, G, B, A and you can think of them as X, Y, Z and W. Now hear me out, we'll make a new "Vector 4" node and connect the "B" of split to the "Y" of the Vector 4. 

Now if you were to connect the vector 3 directly to the Add, you'll get kind of what we want to do here but it looks very linear and not exactly what were going for. What were going to do here is we'll separate the Split and everything connected to it (From the input and behind) and just move them a bit farther to give us some more space. Now before the split goes into the Vector 4, we'll add a "Power" node and link the "B" of split to the "A(1)" of Power. Next we'll add a "Multiply" node, Power's output will go in the "B(1)" of the multiply and the multiply's output will go in the "Y" axis of the Vector 4. Now in terms of the power, it'd be good to have some way to control the intensity of this. So let's go to the blackboard and create a new Vector1 called "curvature". The default value we'll put for this will be "0.004". Now take this out and link it to the "A(1)" of "Multiply". **Save Assets!**

Now if we go to the Scene window we'll see that it's actually working pretty well but not every object is going up at the same time. Back to the Main window, create a new node "Transformation Matrix" and link it to the "A(4x4)" of the Multply node. **Save Assets!**
So back to the Scene window, select any object that has the Atlas texture and modify the curvature parameter to "0.004". We'll do the same thing for the "Snow" texture of our Floor. And finally do the same thing to our player Penguin.

## Gameplay Elements

Now is the time to create Gameplay Prefabs and for that we'll go ahead and create a new folder right under the Assets and call it "Prefab" and under that new folder we'll create another folder called "Element". If you had put any gameplay elements in the scene such as the "Block" or "Log", you can go and drag them from the Hierarchy window to the new "Element" folder we just made. Unity will ask you: Would you like to create a new original Prefab or a variant of this Prefab? We want to create a new **Original Prefab**. We can now double-click the element to enter the Nested Prefab Editor. Depending on the shape of the elements that we will be working with, we'll have to use different type of Collider. In the case of this game we'll mostly be using the Box Collider. Here let's rince and repeat for each elements we have.

## Creating Chunks

Under the Prefab folder, let's create a new folder called "Gameplay" and that's where we'll put our chunks. Then in the Hierarchy window we'll Right-click and create an Empty GameObject that we will call "Chunk". Place it at 0, 0, 0 (Center of the world) and then drag and drop it to the "Gameplay" folder we just made. Enter the Nested Prefab Editor of the chunk and start by placing 2 Plane as our floor. This is something we'll keep for now but eventually we will have to remove.
Now have fun and place some objects however you like, there's only 4 rules.

1. Keep in mind the Z axis and the direction our player is going
2. Make sure that there is at least one way to make it through the chunk without dying. 
3. Only import the elements we made in the Assets/Prefab/Element folder, otherwise the other elements will not work.
4. Keep in mind that there are only 3 rows that our player will be able to run (-3, 0, 3) on the X axis.

Make at least 3 to 5 of these to keep things interesting while making the game and to make it easier to debug as well. **Don't forget to name them for example Chunk1 Chunk2 Chunk3**

## Chunks.cs

After creating a couple of chunks we are finally ready to attack some code. Under "Script" we'll create a new folder called "WorldGeneration". **VERY IMPORTANT** 
Inside the WorldGeneration folder go ahead a Right-click, hover on "Create" and select "C# Script" and call it "Chunk". When creating scripts, make sure to name it at the creation or otherwise you will have to not only change the file name but also the Class name.
Now simply double click on the file to open it in Visual Studio (Or any IDE/TextEditor of your choice). If you need to change the Editor go in the Edit menu, Preferences, and select External Tools to change the External Script Editor.

There are two ways to create an object with C# and have it show up in the Inspector for a quicker and easier value changes. The first way is to make the object public. The second way is to make the item *[SerializeField] private*. that will prevent other classes from changing the value while having it show up in the inspector.

Throughout this whole project we'll delete the "premade" code that is in every C# file that we'll create using Unity. Even though we might rewrite the same functions at times. First thing we'll do here is create a public float that is going to be the length of our Prefab, let's call it chunkLength. This object will have 2 functions, one of them is going to be for showing the chunk and the other is going to be for hiding the chunk. What we want to do here is, once our player has passed a chunk, we don't want to just Delete it and spawn a new one in front. We are going to just disable them and hide them for a moment until we need them again. This optimization technique called "pooling" and we'll implement that here.

Here we can create the two functions, public Chunk ShowChunk() and public Chunk HideChunk(). In the former, all we want to do is take the game object of this script and SetActive(true) and the same for HideChunk but we'll set this one to false. The script should look something like this:

```csharp
public class Chunk: MonoBehaviour
{
   public float chunkLength;
 
   public Chunk ShowChunk()
   {
     gameObject.SetActive(true);
     return this;
   }
 
   public Chunk HideChunk()
   {
    gameObject.SetActive(false);
    return this;
   }
}
```

Now we can go back to Unity and select our chunk, drag and drop the script in the chunk's Inspector and change the Chunk Length value to 20 since we've been using 2 Planes and they are both 10 meters each. Go ahead and repeat this for every chunk made. 

## World Generation script

What we can do now is to just delete the chunks that are currently in the scene because they are going to be instanciated directly from the script. Right-click the WorldGeneration folder and create a new C# Script called "WorldGeneration" then double-click on it to open it up. Same as usual delete the Start and Update functions to start fresh. This script will contain 6 functions: Awake(), Start(), ScanPosition(), SpawnNewChunk(), DeleteLastChunk() and finaly ResetWorld(). They are pretty self explanatory so I'll skip the explaination for now.

Here is what the WorldGeneration should look like:

```csharp
public class WorldGeneration : MonoBehaviour
{
    // Gameplay
    private float chunkSpawnZ;
    private Queue<Chunk> activeChunks = new Queue<Chunk>();
    private List<Chunk> chunkPool = new List<Chunk>();

    // Configurable Fields
    [SerializeField] private int firstChunkSpawnPosition = -10;
    [SerializeField] private int chunkOnScreen = 5;
    [SerializeField] private float despawnDistance = 5.0f;

    [SerializeField] private List<GameObject> chunkPrefab;
    [SerializeField] private Transform cameraTransform;

    private void Awake()
    {
        ResetWorld();
    }

    private void Start()
    {
        // Check if we have an empty chunkPrefab list
        if (chunkPrefab.Count == 0)
        {
            Debug.LogError("No chunk prefab found on the world generator, please assign some chunks!");
            return;
        }

        // try to assign the cameraTransform if not already assigned
        if (!cameraTransform)
        {
            cameraTransform = Camera.main.transform;
            Debug.Log("We've assigned cameraTransform automaticly to the Camera.main");
        }


    }

    public void ScanPosition()
    {
        float cameraZ = cameraTransform.position.z;
        Chunk lastChunk = activeChunks.Peek();
        // Peek is same as : activeChunks[activeChunks.Count-1];

        if (cameraZ >= lastChunk.transform.position.z + lastChunk.chunkLength + despawnDistance)
        {
            SpawnNewChunk();
            DeleteLastChunk();
        }

    }

    private void SpawnNewChunk()
    {
        // Get a random index for which prefab to spawn
        int randomIndex = Random.Range(0, chunkPrefab.Count);


        // does it already exist within our pool
        Chunk chunk = chunkPool.Find(x => !x.gameObject.activeSelf && x.name == (chunkPrefab[randomIndex].name) + "(Clone)");

        // create a chunk if we're not able to find one to reuse
        if (!chunk)
        {
            GameObject go = Instantiate(chunkPrefab[randomIndex], transform);
            chunk = go.GetComponent<Chunk>();
        }

        // place the object, and show it
        chunk.transform.position = new Vector3(0, 0, chunkSpawnZ);
        chunkSpawnZ += chunk.chunkLength;

        // store the value to reuse in our pool
        activeChunks.Enqueue(chunk);
        chunk.ShowChunk();
    }

    private void DeleteLastChunk()
    {
        Chunk chunk = activeChunks.Dequeue();
        chunk.HideChunk();
        chunkPool.Add(chunk);
    }

    public void ResetWorld()
    {
        // reset the chunkSpawnZ
        chunkSpawnZ = firstChunkSpawnPosition;

        for (int i = activeChunks.Count; i != 0; i--)
            DeleteLastChunk();

        for (int i = 0; i < chunkOnScreen; i++)
            SpawnNewChunk();
    }
}
```

## Implementating World Generation

First thing we're going to do here is in the Hierarchy window, we'll create a new empty game object and call it "WorldGeneration". **Don't forget to put it at the center of the world**. Then go ahead a drag and drop the WorldGeneration Script we just made into the WorldGeneration game object's Inspector window. You should be able to see the parameters with the default values that we implemented in the code right here in the Inspector. The important one for now is the "Chunk Prefab", we'll change the value to however many Chunks we have made and simply open that folder and drag them one by one into the "Element" slots. For the "Camera Transform" just go ahead and take our Main Camera and drag it in there. 

If you were to press the Play button right away you will notice that the chunks have been spawned but they do look a bit aweful and also they are not spawning at the right place. We can fix this by changing the "First Chunk Spawn Position" value to something that makes sense for you (in my case it was 5). While we are here I want to make sure to tell you to change the Texture for each and every game objects that you have on the chunks to the Texture that has the "curvature" and the same for the snow floor. 

Now if we want to test our SpawnNewChunk function, we can hit the play button and simply change the camera's direction to face the Z axis. Then grab the camera object and drag it along the Z axis, you'll see that as the camera moves there are new chunks being spawned in front AND old chunks being "deleted" in the back. Looking at the Hierarchy window we can see that the "deleted" chunks are actually just disabled and are being re-used at the time of spawning new chunks.

## Implementing Scene Chunks

There are two main reasons why we need to implement the Scene Chunks. One is that we will add some colliders to them on the left and right side so that the player cannot leave the game chunks. The other is that they will add nice scenery to the game. The reason we did not simply implement the scenery with the game chunks is that we want it to be randomized and give the game more diversity. This is going to be a repeat of the game chunks so I'll just go ahead and give you the bullet point for this one.

- New folder under "Prefab" called "Scenery"
- New empty game object (center of the world) in Hierarchy window and call it "SceneChunk1"
- Put colliders on both sides
- Create two planes for each sides
- Put the snow texture
- Take the elements found in Assets/Artwork/Models/Environement
- Have fun and be creative
- Make as many as you want
- When done with the chunk **Don't forget to put the chunk in our Prefab/Scenery folder**

One more thing before we move on from here, we don't want to have duplicated code to spawn the Scenery so what we can do is: Create a new C# Script in the WorldGeneration folder and call it SceneChunkGeneration. This is going to be a very simple one, in fact it's going to be empty!

```csharp
public class SceneChunkGeneration : WorldGeneration
{

}
```

As you can see the SceneChunkGeneration Inherits from WorldGeneration, so it has all the same functions to it. We can now drag and drop the SceneChunkGeneration to the WorldGeneration Object. Same deal as before we'll attach our Main Camera to it and change the Chunk Prefab value to however many scenes we made and drag them one by one in there.
**Important thing** before we move on, every scene chunk we made has to have the Chunk.cs script to them so go ahead and do that. Don't forget to put the Chunk length value as well and it should be at 10 since the scenes only have 1 Plane of 10 meters each (Unless you did something funky and that is totally okay :) ). 

## Input System

In the previous section, we made sure to instantiate the world as the camera move. Now it is time to have our player start running through this. However, there is one more prerequisite before we get to that point, and that is of the Inputs. We will now have to get the input manager as a package because Unity now works with small modules which is great for us as we build smaller games there is a lot less overhead when it comes to package size. 
Let's open up the Window menu and select the Package Manager. Then look for the Input System, as always **make sure that you are looking for "All Packages" or "Unity Registry"**. Installing this package Unity will ask you to restart the application, it is important to do so. Once the application has been restarted you will be asked to enable the input system and again, it is important to enable it. By enabling the new Input System you are going to disable the old one. 

Let's now create a new folder under script and call it "Inputs". Then go over the Edit menu and select "Project Settings...", you will find the new Input System Package is now here and so is the Input Manager. The input manager should have an error sign on it because it is disabled and we are no longer using the old inputs. Go in the Input System Package and let's create a Setting Asset. You'll see that it has been put in the Settings folder in our project, drag and drop it into our "Inputs" folder we just created. We will be using all of these settings as they come by default, the only thing we will change is at the bottom. The "Supported Devices" is a list of well, supported devices, so you could say "Mouse" or "Touchscreen" and so on. But if you were to leave it completely empty, the Input System will assume that every input received are supported. I encourage you to leave it empty at the moment until we are done with the game. Hit save (or CTRL + S) and close the window. 

## Creating our first Input set

This part is about creating an Input action. It will be an asset that helps you generate some code that will then decide which inputs are being looked for. To get started, we'll Right-click our "Inputs" folder and hover on "Create" then select "Input Action". We'll call this one "RunnerInputAction", and we can open it with a double-click. A new window will open and it will be important to follow each steps.
If we have a brief look at how the window is set up, you'll find on the left hand side "Action Maps". These action maps will contain "Actions" in the middle pane, and these actions will have "Properties" on the right hand side. Before we get into action maps, however, let's have a look at the control scheme at the top left where it currently says "No Control Schemes". Let's add one and call it "Computer". Then where it says "List is Empty" click the "+" button and select "Mouse", then add another one and select "Keyboard". For the "Requirements:" we'll select "Optional". Then we can create another Scheme and call it "Mobile". For the list of inputs we will select "Touchscreen", and we will do the same as before for the requirements. Now we have two different schemes, we can either select one at a time and play around with them or just select "All Control Schemes" which is what we will do. 

We will now create our Action Map. Click on the "+" button next to Action Maps and call it "Gameplay", as you can see now that we have created the map, there is aleady an Action and some properties for that as well. Let's rename the action to "Tap". So now "Tap" is our action, how can I produce a tap? I can produce it by clicking on my touchscreen but I can also produce it by clicking on my mouse. That's exactly what we are going to do here. Click on the "arrow" button that is left of the "Tap", this is where we will "bind" our input to the action. Click on the "<No Binding>" and you will see on the properties pane that we have access to the binding's properties. Under "Binding" change the path to "Left Button [Mouse]", then on the "Tap" row you will see a "+" button and select "Add Binding". For the touchscreen you will be looking for the "Touch #0/Tap[Touchscreen]". Now we have an action "Tap" that can be executed by "Left Button Mouse" or "Touch / Tap Touchscreen". For both bindings we will select which control scheme it is used for respectively. Now if we select the "Tap" we'll see that this action will return a certain type of value, in this case it is set to "Button" and we will be leaving at that. The "Interaction" is going to modify your input to follow a certain condition. In our case we will select the "Press", on the "Trigger Behavior" you will need to select the "Press Only". And finally, the "Processor" is the value we are sending over, but we don't need any of that here.

This was a "Tap", it was fairly simple since it's a type "Button" which only returns a true or false. Now let's spice things up a bit. We're going to create a new action and that action is going to be the "cursor position". Since we are building this for mobile, let's call it "TouchPosition". This action will have a different type because we are not trying to send a true or false, we are trying to send a Vector2. So head over to the "Action Type" and change the Type to "Pass Through" and the "Control Type" will be "Vector2". We don't actually need an Interaction here so if there is, remove it. Now this means that since we have a Pass Through value, as soon as the binding is being called by, for example, moving the mouse, we will receive that value. For the "Binding" of TouchPosition we will look for "Position[Mouse]" and we'll add a second one for "Position[Touchscreen]". We'll go ahead and set the control scheme for both of these bindings. And as for the Interaction and Processors we can leave those empty.

We will need two more actions for our game and those are the "StartDrag" and "EndDrag" actions. Both of them will be set as "Pass Through" and control type "Button". For the StartDrag, the Interaction will be set on "Press" and "Press Only", and the EndDrag is going to be "Press" and "Release Only". For the bindings we'll look for the Left Button Mouse and the Touchscreen/touch*/press on both actions. **Make sure to set the control scheme for the appropriate device**. Leave the Interaction and Processors empty for those bindings.

Now there is one last thing to do before we can close this window. Select the "Touch #0/Tap" action and click on the "T" button next to the "Path" in the Properties. This will show you the string definition of all your actions. What we need to do here is change the string "<Touchscreen>/touch0/tap" to "<Touchscreen>/touch*/tap". This means that if, for example, you have a finger leaning on the touchscreen and with your other finger you make a swipe, the game will be able to recognize it. Otherwise with the 0 only, the game will only register 1 finger at a time.

Go ahead and click "Save Asset" and close the window. Now let's select the "RunnerInputAction" from the Inputs folder and in the Inspector, click on the "Generate a C# Class". The default settings should be the folder that we are in so we'll just click on "Apply". We now have a big C# script with a lot of JSON that has been generating for us which you can take a look at but we will not modify anything in there.

## The Input Manager

We are now going to create our own version of the Input Manager, this will sit in the middle of all call we do to input and the RunnerInputAction that we've created before. Right in the Inputs folder let's create a new C# Script called "InputManager" and open it. As usual we'll get rid of everything and start from scratch.

We are going to create a static instance, we don't do that quite often, and when we do, we have to make sure that it's an object that will only be at a single place in the game. So it's not going to be a script that is going to be used twice you could say. So this InputManager will be on an object and that object will persist thoughout the whole game. You could see it as some sort of singleton but also not quite a full singleton. 

We'll start with a private static InputManager called instance. Then a public static InputManager also called Instance (with a capital "I"), and this one will only have a get, and will return the instance. So the only person/class/script that can set instance would be our private self.

We will actually do that right now in a Awake function we'll say instance is equal to this. We'll also add DontDestroyOnLoad(gameObject) so we specify that we don't want to destroy this whole game object on Load. By doing this, whenever this object will be instantiated, it is foing to set itself as the static instance and after that from other scripts we can call the instance with capital "I".

Next thing we'll need is the ActionScheme which is going to be a private RunnerInputAction called actionScheme. This is created from the script we've generated in the previous step. We don't really need to assign it to anything so we don't need it public or even as SerializeField, instead we're going to construct one with the "new" call. We'll do that in a separate function called SetupControl, which we'll also call that function from the Awake. After constructing the RunnerInputAction we're going to register different actions to whatever function we have. So by saying actionScheme.Gameplay (which is the name of our ActionMap) we'll be able to call the actions we've defined earlier.

Now let's do the swipe logic. First we'll have to put some public AND private properties such as:
1. bool Tap
2. Vector2 TouchPosition
3. bool SwipeLeft
4. bool SwipeRight
5. bool SwipeUp
6. bool SwipeDown

We will also add one more for the privates and that is going to be a Vector2 startDrag. Before we continue with that we also need two more functions that we will call ResetInputs and LateUpdate. In late update we'll just call ResetInputs. Here is what is going to happen in the ResetInputs, first, tap is going to equal to false. Also, swipe up, down, left and right are also going to be equal to false. If we wanted to have one ugly "one-liner" we could say ```tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;```. Now the only thing we didn't reset in here is the touchPosition and the startDrag, which we will do within four (4) new functions called: OnEndDrag, OnStartDrag, OnPosition, and OnTap. Just to explain a little further here, every single frame, we are going to be looking for events. These events will be parsed in a Dynamic Update because that is how it has been set within the Input Settings. So if we're Tapping, the OnTap function is going to be true. At a later time during the frame (LateUpdate) we're going to reset the inputs to false.

OnTap is going to be the easiest here, we'll just say ```tap = true;``.
OnPosition is also pretty easy, we have to get the value from context and put it under "position". So touchPosition is going to be equal to the context, and we'll be Reading the value type Vector2. Like this we will be getting the position of our mouse and/or touchscreen. 
Next is OnStartDrag. StartDrag is going to be equal to touch position **Make sure to use the one with the lowecase "t"**.
Finally, we have OnEndDrag. This is really the one where we will do the Swipe logic so it might get a bit complicated, hopefully we're understanding it well here. 

We will start by getting a Delta position on where our cursor/finger is, based on where we started our drag. So we'll do a Vector2 delta is equal to touchPosition minus the startDrag, that will give us where our cursor/finger has traveled from the start to the end of the drag. Then what we'll do is we'll get the sqare distance of that delta's squared Magnitude. Now let's do, if the squared distance is bigger than a certain amount (How far do you have to swipe before it is being considered a swipe) we will use a hardcoded value of 50.0f here. We can actually have a new property like this: [SerializeField] private float sqrSwipeDistance = 50.0f; to keep us from using straigh hardcoded values. So this here gives us two different routes, either this is a confirmed swipe OR we've just released before we had the time to do a swipe. If that is the case, then we'll do the following. We'll say that startDrag is going to be called back to zero (Vector2.zero). So once we're done with the swipe/noSwipe we reset startDrag back to zero. Now assuming that we have a swipe, we have to know in which direction the swipe is going to be. For that we'll need a little bit of Maths. We'll start with "x" is equal to Mathf.Absolute(delta.x). We'll do the exact same for "y". This will give us the absolute value, which means it removes all the negative values and turn them into positives. Knowing that we can check if "x" was bigger than the "y", it will mean we're either going left or right. Now if that's not the case, it would mean that we're either going up or down. If we know that our swipe distance in "x" is bigger than "y", the only thing that will tell us if it was left or right will be our value, but without the absolute on it. So if delta.x is positive, it will mean that we are going right. So if delta.x is bigger than 0, swipeRight is going to be equal to true, else swipeLeft is going to be true. We'll apply the same logic for "y".

This is what the InputManager should look like:

```csharp
public class InputManager : MonoBehaviour
{
    // There should be only one InputManager in the scene
    private static InputManager instance;
    public static InputManager Instance { get { return instance;  } }

    // Action scheme
    private RunnerInputAction actionScheme;

    // Config
    [SerializeField] private float sqrSwipeDeadzone = 50.0f;

    #region public properties
    public bool Tap { get { return tap; } }
    public Vector2 TouchPosition { get { return touchPosition;  } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
    #endregion

    #region private properties
    private bool tap;
    private Vector2 touchPosition;
    private Vector2 startDrag;
    private bool swipeLeft;
    private bool swipeRight;
    private bool swipeUp;
    private bool swipeDown;
    #endregion

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        SetupControl();
    }
    private void LateUpdate()
    {
        ResetInputs();
    }
    private void ResetInputs()
    {
        tap = false;
        swipeLeft = false;
        swipeRight = false;
        swipeUp = false;
        swipeDown = false;
    }

    private void SetupControl()
    {
        actionScheme = new RunnerInputAction();

        // Register different actions
        actionScheme.Gameplay.Tap.performed += ctx => OnTap(ctx);
        actionScheme.Gameplay.TouchPosition.performed += ctx => OnPosition(ctx);
        actionScheme.Gameplay.StartDrag.performed += ctx => OnStartDrag(ctx);
        actionScheme.Gameplay.EndDrag.performed += ctx => OnEndDrag(ctx);
    }

    private void OnTap(InputAction.CallbackContext ctx)
    {
        tap = true;
    }
    private void OnPosition(InputAction.CallbackContext ctx)
    {
        touchPosition = ctx.ReadValue<Vector2>();
    }
    private void OnStartDrag(InputAction.CallbackContext ctx)
    {
        startDrag = touchPosition;
    }
    private void OnEndDrag(InputAction.CallbackContext ctx)
    {
        Vector2 delta = touchPosition - startDrag;
        float sqrDistance = delta.sqrMagnitude;

        // Confirmed swipe
        if(sqrDistance > sqrSwipeDeadzone)
        {
            float x = Mathf.Abs(delta.x);
            float y = Mathf.Abs(delta.y);

            if(x > y) // Left or Right
            {
                if(delta.x > 0)
                    swipeRight = true;
                else
                    swipeLeft = true;
            }
            else      // Up or Down
            {
                if (delta.y > 0)
                    swipeUp = true;
                else
                    swipeDown = true;
            }
        }

        startDrag = Vector2.zero;
    }

    public void OnEnable()
    {
        actionScheme.Enable();
    }

    public void OnDisable()
    {
        actionScheme.Disable();
    }
}
```

One last little thing before we are done with the InputManager and that is the "Order". If for example our Dynamic Update starts the frame with the PlayerMotor trying to set an input, then the InputManager will say "No all the inputs here are set as false" and the late update will reset the inputs to false. What we need is for the InputManager to be the first in frame, say "Hey, all the inputs are false", then the PlayerMotor is gonna say "Ok I have an input here let's change that value", and finally at the end of the frame, late update resets the values to false.

To do so, we'll go in the Edit menu and select "Project Settings", then select "Script Execution Order". Click on the "+" button and look for our InputManager. We'll need to place this right in between "UnityEngine.InputSystem.PlayerInput" and "UnityEngine.Experimental....". Hit "Apply" and save the project.

