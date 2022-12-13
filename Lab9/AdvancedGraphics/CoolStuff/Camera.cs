using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsHelper
{
    public class Camera
    {
        public Point cameraPosition;
        public Vector cameraDirection;
        public Vector cameraUp;
        public Vector cameraRight;
        const double cameraRotationSpeed = 1;
        double yaw = 0.0, pitch = 0.0;

        public Camera()
        {
            cameraPosition = new Point(-10, 0, 0);
            cameraDirection = new Vector(1, 0, 0);
            cameraUp = new Vector(0, 0, 1);
            cameraRight = (cameraDirection * cameraUp).normalize();
        }

        public void move(double leftright = 0, double forwardbackward = 0, double updown = 0)
        {
            cameraPosition.Xf += leftright * cameraRight.x + forwardbackward * cameraDirection.x + updown * cameraUp.x;
            cameraPosition.Yf += leftright * cameraRight.y + forwardbackward * cameraDirection.y + updown * cameraUp.y;
            cameraPosition.Zf += leftright * cameraRight.z + forwardbackward * cameraDirection.z + updown * cameraUp.z;
        }

        public Point toCameraView(Point p)
        {
            return new Point(
                cameraRight.x * (p.Xf - cameraPosition.Xf) + cameraRight.y * (p.Yf - cameraPosition.Yf) +
                cameraRight.z * (p.Zf - cameraPosition.Zf),
                cameraUp.x * (p.Xf - cameraPosition.Xf) + cameraUp.y * (p.Yf - cameraPosition.Yf) +
                cameraUp.z * (p.Zf - cameraPosition.Zf),
                cameraDirection.x * (p.Xf - cameraPosition.Xf) + cameraDirection.y * (p.Yf - cameraPosition.Yf) +
                cameraDirection.z * (p.Zf - cameraPosition.Zf));
        }

        public Point toWorldView(Point p)
        {
            return new Point(
                cameraRight.x * p.Xf + cameraUp.x * (p.Yf) + cameraDirection.x * (p.Zf) + cameraPosition.Xf,
                cameraRight.y * p.Xf + cameraUp.y * (p.Yf) + cameraDirection.y * (p.Zf) + cameraPosition.Yf,
                cameraRight.z * p.Xf + cameraUp.z * (p.Yf) + cameraDirection.z * (p.Zf) + cameraPosition.Zf
            );
        }

        public void changeView(double shiftX = 0, double shiftY = 0)
        {
            var newPitch = Math.Clamp(pitch + shiftY * cameraRotationSpeed, -89.0, 89.0);
            var newYaw = (yaw + shiftX) % 360;
            if (newPitch != pitch)
            {
                AffineTransformations.rotateVectors(ref cameraDirection, ref cameraUp, (newPitch - pitch), cameraRight);
                pitch = newPitch;
            }

            if (newYaw != yaw)
            {
                AffineTransformations.rotateVectors(ref cameraDirection, ref cameraRight, (newYaw - yaw), cameraUp);
                yaw = newYaw;
            }
        }
    }
}