using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    const string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    Material defaultMaterial;

    private Transform _selection;
    
    private void Update()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            if(selectionRenderer.material == highlightMaterial)
            {
                selectionRenderer.material = defaultMaterial;
            }
            else
            {
                defaultMaterial = selectionRenderer.material;
            }
            _selection = null;
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();

                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                }

                _selection = selection;
            }
        }
    }
}