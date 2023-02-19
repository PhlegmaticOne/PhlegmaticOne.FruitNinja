using Abstracts.Commands;
using UnityEditor;
using UnityEngine;

namespace Concrete.Commands.ButtonCommands
{
    public class ExitCommand : ICommand
    {
        public void Execute()
        {
            #if UNITY_EDITOR
            if(EditorApplication.isPlaying) 
            {
                EditorApplication.isPlaying = false;
                return;
            }
            #endif
            Application.Quit();
        }
    }
}