using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ObjectInteraction : MonoBehaviour
{
    [SerializeField] private float _maxDistance = 2f;
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private GameObject _interactionText;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        _interactionText.SetActive(false);
    }

    private void Update()
    {
        CheckForTarget();
    }

    private void CheckForTarget()
    {
        Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _maxDistance, _targetLayer))
        {
            if (hit.collider.CompareTag("Target"))
            {
                _interactionText.SetActive(true);

                if (Input.GetMouseButtonDown(0))
                {
                    SceneManager.LoadScene("Scene2D");
                }
            }
        }
        else
        {
            _interactionText.SetActive(false);
        }
    }
}