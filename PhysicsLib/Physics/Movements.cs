using System;
using UnityEngine;

namespace Physics
{
    public static class Movements
    {
        /// <summary>
        /// Calculate the new pos of the object in MRU
        /// </summary>
        /// <param name="pos">Position of the object</param>
        /// <param name="speed">Speed of the object</param>
        /// <returns></returns>
        public static float CalculateMRU(float pos, float speed)
        {
            pos += speed * Time.deltaTime;
            return pos;
        }

        public static Vector3 CalculateMRU(Vector3 pos, float speed, Vector3 dir)
        {
            dir *= (speed * Time.deltaTime);
            pos += dir;
            return pos;
        }

        /// <summary>
        /// Calculate the new pos of the object in MRUV
        /// </summary>
        /// <param name="pos">Position of the object</param>
        /// <param name="speed">Speed of the object</param>
        /// <param name="acceleration">Acceleration of the object</param>
        /// <returns></returns>
        public static float CalculateMRUV(float pos,ref float speed, float acceleration)
        {
            pos += speed * Time.deltaTime + 0.5f * acceleration * (float)Math.Pow(Time.deltaTime, 2);
            speed -= acceleration;
            return pos;
        }

        /// <summary>
        /// Calculate the new pos of the object in oblique shot
        /// </summary>
        /// <param name="pos">Position of the object</param>
        /// <param name="rot">Rotation of the object</param>
        /// <param name="speed">Speed of the object</param>
        /// <param name="gravity">Gravity of the world</param>
        /// <returns></returns>
        public static Vector3 CalculateObliqueShot(Vector3 pos, Vector3 rot, float speed,ref float actualSpeed, float gravity)
        {
            float ang = rot.z * Mathf.Deg2Rad;
            float vel = speed * Mathf.Cos(ang);
            pos.x += vel * Time.deltaTime;

            ang = rot.z * Mathf.Deg2Rad;
            vel = actualSpeed * Mathf.Sin(ang);
            pos.y += vel * Time.deltaTime - 0.5f * gravity * Mathf.Pow(Time.deltaTime, 2);
            actualSpeed -= gravity;

            return pos;
        }


        public static Vector3 CalculateMCU(Vector3 center, float radio, float angle)
        {
            Vector3 nPos = ((radio * Mathf.Cos(angle) * Vector3.right) + (radio * Mathf.Sin(angle) * Vector3.up));
            nPos += center;
            return nPos;
        }

        public static float CalculateAngularVelocity(float angleI, float angleF, float timeI, float timeF)
        {
            float angle = angleI - angleF;
            float time = timeI - timeF;
            return angle / time;
        }
    }
}
