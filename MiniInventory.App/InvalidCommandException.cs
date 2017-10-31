using System;

namespace MiniInventory.App
{
	public class InvalidCommandException : Exception
    {
        public string GetUserMessage()
        {
            return "Ogiltigt kommando.";
        }
    }
}
