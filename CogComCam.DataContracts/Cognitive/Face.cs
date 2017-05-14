using System;

namespace CogComCam.DataContracts.Cognitive
{
    public class Face
    {
        public Guid Id { get; set; }

        public FaceLocation Location { get; set; }
    }
}