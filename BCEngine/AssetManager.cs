using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace BCEngine
{

    public class AssetManager
    {
        public static SpriteFont MainFont { get; set; }
        private static List<Texture2D> ListTexture2D = new List<Texture2D>();
        private static List<Song> ListSongs = new List<Song>();
        private static List<SoundEffect> ListSoundEffects = new List<SoundEffect>();

        public static void Load(ContentManager pContent)
        {
            MainFont = pContent.Load<SpriteFont>("mainfont");

        }

        public static void LoadTexture2D(ContentManager pContent, string pFileName)
        {
            bool exist = false;
            foreach (Texture2D texture in ListTexture2D)
            {
                if (texture.Name == pFileName){
                    exist = true;
                    break;
                }
            }
            if (!exist){
                Debug.WriteLine("Load texture "+pFileName);
                ListTexture2D.Add(pContent.Load<Texture2D>(pFileName));
            }
        }

        public static void LoadSong(ContentManager pContent, string pFileName)
        {
            bool exist = false;
            foreach (Song song in ListSongs)
            {
                if (song.Name == pFileName){
                    exist = true;
                    break;
                }
            }
            if (!exist){
                Debug.WriteLine("Load song "+pFileName);
                ListSongs.Add(pContent.Load<Song>(pFileName));
            }
        }
        public static void LoadSoundEffect(ContentManager pContent, string pFileName)
        {
            bool exist = false;
            foreach (SoundEffect effect in ListSoundEffects)
            {
                if (effect.Name == pFileName){
                    exist = true;
                    break;
                }
            }
            if (!exist){
                Debug.WriteLine("Load Sound effect "+pFileName);
                ListSoundEffects.Add(pContent.Load<SoundEffect>(pFileName));
            }
        }

        

        public static Texture2D GetTexture2D(string pFileName)
        {
            foreach (Texture2D texture in ListTexture2D)
            {
                if (texture.Name == pFileName)
                    return texture;
            }
            Debug.WriteLine("GetTexture2D : "+ pFileName +" not found");
            return null;
        }
           public static Song GetSong(string pFileName)
        {
            foreach (Song song in ListSongs)
            {
                if (song.Name == pFileName)
                    return song;
            }
            Debug.WriteLine("GetSong : "+ pFileName +" not found");
            return null;
        }    public static SoundEffect GetSoundEffect(string pFileName)
        {
            foreach (SoundEffect effect in ListSoundEffects)
            {
                if (effect.Name == pFileName)
                    return effect;
            }
            Debug.WriteLine("GetSoundEffect : "+ pFileName +" not found");
            return null;
        }

    }

}