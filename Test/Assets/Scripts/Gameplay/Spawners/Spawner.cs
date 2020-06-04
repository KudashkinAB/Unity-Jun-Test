using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Gameplay.Helpers;

namespace Gameplay.Spawners
{
    public class Spawner : MonoBehaviour
    {

        [SerializeField]
        private List<GameObject> _objectList; //Спавн рандомного объекта из списка
        
        [SerializeField]
        private Transform _parent;
        
        [SerializeField]
        private Vector2 _spawnPeriodRange;
        
        [SerializeField]
        private Vector2 _spawnDelayRange;

        [SerializeField]
        private bool _autoStart = true;

        [SerializeField]
        private bool _randomPosition = false; //Рандомизация положения обьекта при спавне по оси Y

        private void Start()
        {
            if (_autoStart)
                StartSpawn();
        }


        public void StartSpawn()
        {
            StartCoroutine(Spawn());
        }

        public void StopSpawn()
        {
            StopAllCoroutines();
        }


        private IEnumerator Spawn()
        {
            yield return new WaitForSeconds(Random.Range(_spawnDelayRange.x, _spawnDelayRange.y));
            
            while (true)
            {
                GameObject spawnedObject = _objectList[Random.Range(0, _objectList.Count)];
                float randomMove = 0f;
                if (_randomPosition)
                {
                    randomMove = Random.Range(GameAreaHelper.GetHorizontalCameraBounds().x, GameAreaHelper.GetHorizontalCameraBounds().y);
                }
                Instantiate(spawnedObject, transform.position + new Vector3(randomMove, 0f, 0f), transform.rotation, _parent);
                yield return new WaitForSeconds(Random.Range(_spawnPeriodRange.x, _spawnPeriodRange.y));
            }
        }
    }
}
