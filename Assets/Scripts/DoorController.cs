using System.Collections;
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
        private GameObject _doorCamera;
        [SerializeField]
        [Tooltip("Time to see lever animation")]
        private float _cameraDelayForLeverAnimation = 0.5f;
        [SerializeField]
        [Tooltip("CinemachineBrain blend time")]
        private float _cameraDelayForBlend = 2.0f;
        [SerializeField]
        [Tooltip("Time needed to complete door movement")]
        private float _cameraDelayForDoorOpening = 1.0f;
        
        private InputManager _inputManager;

        //Get referenses for block player movement
        protected override void Start()
        {
            base.Start();
            _inputManager = InputManager.TryGetInstance();
        }

        // Call this function on KeyOperatedZone Actions for activation
        public void OpenDoor()
        {
            if (_doorCamera != null && _inputManager != null)
            {
                StartCoroutine(OpenDoorRoutine());
            }
        }

        // Open door after camera finish movement, then return camera to the player
        private IEnumerator OpenDoorRoutine()
        {
            BlockPlayerMovement(true);
            yield return new WaitForSeconds(_cameraDelayForLeverAnimation);
            _doorCamera.SetActive(true);
            yield return new WaitForSeconds(_cameraDelayForBlend);
            AuthorizeMovement();
            yield return new WaitForSeconds(_cameraDelayForDoorOpening);
            _doorCamera.SetActive(false);
            yield return new WaitForSeconds(_cameraDelayForBlend);
            BlockPlayerMovement(false);
        }

        // prevents user input and horizontal movement of character
        private void BlockPlayerMovement(bool state)
        {
            _inputManager.InputDetectionActive = !state;
            _inputManager.ResetMovement();
        }
    }

}
