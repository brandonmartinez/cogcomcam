using System;

namespace CogComCam.DataContracts.Cognitive
{
    public class Face
    {
        public Guid Id { get; set; }

        public FaceLocation Location { get; set; }
    }

    public class FaceLocation
    {
        public int Bottom => Top + Height;

        public int Height { get; set; }

        public int Left { get; set; }

        public int Right => Left + Width;

        public int Top { get; set; }

        public int Width { get; set; }
    }
}