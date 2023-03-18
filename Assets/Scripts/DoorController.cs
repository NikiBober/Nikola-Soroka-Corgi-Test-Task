using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.CorgiEngine
{
    /// <summary>
    /// This component controls camera movement to the door and activates platform movement
    /// </summary>

    public class DoorController : MovingPlatform
    {
        [Header("Door Camera Control")]

        [SerializeField]
        [Tooltip("Virtual Cinemachine camera adjusted to the door")]
        GameObject _doorCamera;
        [SerializeField]
        [Tooltip("CinemachineBrain blend time")]
        float _cameraDelayForBlend = 2.0f;
        [SerializeField]
        [Tooltip("Time needed to complete door movement")]
        float _cameraDelayForDoorOpening = 1.0f;

        // Call this function on KeyOperatedZone Actions
        public void OpenDoor()
        {
            StartCoroutine(OpenDoorRoutine());
        }

        IEnumerator OpenDoorRoutine()
        {
            _doorCamera.SetActive(true);
            yield return new WaitForSeconds(_cameraDelayForBlend);
            AuthorizeMovement();
            yield return new WaitForSeconds(_cameraDelayForDoorOpening);
            _doorCamera.SetActive(false);
        }
    }

}
