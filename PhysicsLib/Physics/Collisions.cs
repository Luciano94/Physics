using System;
using UnityEngine;

namespace Physics
{
    public static class Collisions
    {

        /// <summary>
        /// Detect collisions between two boxes
        /// </summary>
        /// <param name="b1Pos">position of the first box</param>
        /// <param name="b1Width">width of the first box</param>
        /// <param name="b1Height">Height of the first box</param>
        /// <param name="b2Pos">position of the second box</param>
        /// <param name="b2Width">width of the second box</param>
        /// <param name="b2Height">Height of the second box</param>
        /// <returns></returns>
        public static bool CompareBox(Vector2 b1Pos, float b1Width, float b1Height,
                               Vector2 b2Pos, float b2Width, float b2Height)
        {
            Vector2 diff = b1Pos - b2Pos;
            float diffX = Mathf.Abs(diff.x);
            float diffY = Mathf.Abs(diff.y);

            if (diffX <= (b1Width / 2 + b2Width / 2) &&
                diffY <= (b1Height / 2 + b2Height / 2))
            {
                return true;
            }
            else return false;
        }

        public static bool CompareBox(Box b1, Box b2)
        {
            Vector2 diff = b1.pos - b2.pos;
            float diffX = Mathf.Abs(diff.x);
            float diffY = Mathf.Abs(diff.y);

            if (diffX <= (b1.width / 2 + b2.width / 2) &&
                diffY <= (b1.height / 2 + b2.height / 2))
            {
                return true;
            }
            else return false;
        }
    }

    public class Box: MonoBehaviour
    {
        public Vector3 pos;
        public float width;
        public float height;

        void SetData(Vector3 _pos, float _width, float _height)
        {
            pos = _pos;
            width = _width;
            height = _height;
        }
    }
}
