namespace MiniInventory.App
{
    public static class Texts
    {
        public const string Welcome = @"
Välkommen till lagerhanteringen!";

        public const string Instructions = @"
Giltiga kommandon:
För inleverans: I, följt av antal (""I5"")
För sälj: S, följt av antal (""S2"")
För lagersaldo: L
För att avsluta: [Enter]

Antal ska vara ett positivt heltal, max nio siffror.

Ange ett kommando:";
    }
}