using UnityEngine;

namespace Utils
{
    public static class PlayerUtils
    {
        private const float MaxGroundAngle = 45f;
        private const float MaxSpeed = 5f;

        public static bool CheckCanJump(ContactPoint[] contacts, float maxAngel = MaxGroundAngle)
        {
            var canJump = false;

            foreach (var contact in contacts)
            {
                var angle = Vector3.Angle(contact.normal, Vector3.up);

                if (angle < maxAngel)
                {
                    canJump = true;
                    break;
                }
            }

            return canJump;
        }

        public static float GetSpeedMultiplier(float velocity, float force, bool grounded = true,
            float maxSpeed = MaxSpeed)
        {
            if (Mathf.Abs(velocity) > maxSpeed && Mathf.Abs(force) > 0)
                return 0f;

            if (!grounded)
                return 0.2f;


            return 1f;
        }
    }
}