# Unity Simple Audio Manager
<h2><b>Summary</b></h2>
This is a simple <b>Audio Manager</b> for Unity Engine with pooling. It was thought to be used in a small or medium sized project.

This Unity package was created in Unity Engine v. <i>2021.3.14f1</i>. It should be used in another version without any error.

<h2><b>Installion</b></h2>
<ol>
<li>Clone the repository to any place in your computer. There is a Unity Package file in Unity-Simple-Audio-Manager\Assets\AudioManagerByOzzysDen\<b>AudioManagerByOzzysDen.unitypackage</b>.</li>
<li>Open your Unity project or create a new one. Go to <i>Assets/Import Package/Custom Package</i> on the top navigation menu and import AudioManagerByOzzysDen.unitypackage to your project.</li>
<li>Package is in your project now.</li>
</ol>
<h2><b>Usage</b></h2>
<ol>
<li>In the Assets folder you'll find a Prefabs folder (<i>AudioManagerByOzzysDen\Prefabs</i>). Simply drag <b>AudioManager</b> prefab to your Hierarchy on your scene.
<li>If you want to use same <b>AudioManager</b> in all of your scenes tick DontDestroy on the prefab. This will make the prefab Singleton pattern. If you want to make it a Singleton I recommend putting the <b>AudioManager</b> in your starting scene only.
<li>You'll find another prefab in the same directory called <b>AudioPlayer</b>. This prefab has the <b>AudioSource</b> component, which is responsible for playing any Audio in your game. And it is pooled to save memory and resources. This means an instance of <b>AudioPlayer</b> will be created anytime there is no any empty (not playing) <b>AudioPlayer</b> prefab exists under <b>AudioManager</b>. Once a <b>AudioPlayer</b> is created it won't be destroyed, any of them will be used repeatedly.
<li>There is AudioFiles ScriptableObject called <b>Audio Data</b> in Assets\AudioManagerByOzzysDen directory. Here you have to set your audio clip files in the list.
<li>This asset was intended to play Sound FX but you also use it to play game music as well. You just have to tick isLoop to play the game music in a loop. There will be a pseudo random Music Player I will share in the future. I'll pass the link here as soon as it is ready.


![AudioData_img](https://user-images.githubusercontent.com/22709206/205247567-d78392db-4093-42ba-8e9a-21a730b43fce.png)


<li>Finally, there is a PoolSize variable on the <b>AudioManager</b>. You can set the initial pool size according to your project's scale. Then on the start manager will create defined number of <b>AudioPlayer</b> prefab under <b>AudioManager</b> in the Hierarchy (default is 5).



![AudioManager_Img](https://user-images.githubusercontent.com/22709206/205246880-56130d76-c010-4df9-9482-568f6a7fb71b.png)
