using UnityEngine;

namespace Gameplay.Helpers
{
    public static class GameAreaHelper
    {

        private static Camera _camera;
        //Чтобы не пересчитывать каждый апдейт и не повторять код
        static float camHalfHeight;
        static float camHalfWidth; 
        static Vector2 camPos;
        static float topBound;
        static float bottomBound; 
        static float leftBound;
        static float rightBound;

        static GameAreaHelper() //Чтобы не переопределять каждый апдейт
        {
            _camera = Camera.main;
            camHalfHeight = _camera.orthographicSize;
            camHalfWidth = camHalfHeight * _camera.aspect;
            camPos = _camera.transform.position;
            topBound = camPos.y + camHalfHeight * 1.25f;
            bottomBound = camPos.y - camHalfHeight;
            leftBound = camPos.x - camHalfWidth;
            rightBound = camPos.x + camHalfWidth;
        }

        
        public static bool IsInGameplayArea(Transform objectTransform, Bounds objectBounds)
        {
            var objectPos = objectTransform.position;

            return (objectPos.x - objectBounds.extents.x < rightBound)
                && (objectPos.x + objectBounds.extents.x > leftBound)
                && (objectPos.y - objectBounds.extents.y < topBound)
                && (objectPos.y + objectBounds.extents.y > bottomBound);

        }

        public static void EncloseInBorders(Transform objectTransform, Bounds objectBounds) //Заключение объекта в границах камеры
        {
            objectTransform.position = new Vector2(
                Mathf.Clamp(objectTransform.position.x, leftBound + objectBounds.extents.x, rightBound - objectBounds.extents.x), 
                Mathf.Clamp(objectTransform.position.y, bottomBound + objectBounds.extents.y, topBound - objectBounds.extents.y));
        }

        public static Vector2 GetHorizontalCameraBounds() //Получение горизонтальных границ камеры
        {
            return new Vector2(leftBound, rightBound);
        }
        
    }
}
