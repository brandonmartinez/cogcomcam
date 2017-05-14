namespace CogComCam.DataContracts.Cognitive {
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