using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager S;

    public GameObject availableResourcePrefab;
    public GameObject availableResources;
    public GameObject purchasedResources;
    public GameObject activatedResources;

    private Hashtable nameToGO = new Hashtable();
    private Hashtable nameToUI = new Hashtable();

    private void Awake()
    {
        // Initialize Singleton instance.
        S = this;

        // Find each Resource in the Scene and create an associated
        // UI component under available resources.
        foreach (Resource resource in GetComponentsInChildren<Resource>())
            CreateAvailableResource(resource);
    }

    private void CreateAvailableResource(Resource resource)
    {
        // Add GO to hash table.
        nameToGO.Add(resource.name, resource);

        // Instantiate UI for resource.
        GameObject uiResource = Instantiate(availableResourcePrefab);

        // Add UI to hash table.
        nameToUI.Add(resource.name, uiResource);

        // Set name.
        uiResource.name = resource.name;

        // Parent under available resources.
        uiResource.transform.SetParent(availableResources.transform);

        // Set UI image.
        uiResource.GetComponent<Image>().sprite = resource.GetComponent<SpriteRenderer>().sprite;

        // Enable and set cost.
        uiResource.GetComponentInChildren<Text>().enabled = true;
        uiResource.GetComponentInChildren<Text>().text =  "$" + resource.cost.ToString();
    }

    public void PurchaseResource(Resource resource)
    {
 
        // Deactivate the resource in Scene.
        resource.gameObject.SetActive(false);

        // Get UI from hash table.
        GameObject uiResource = (GameObject)nameToUI[resource.name];

        // Find Text containing Cost and disable.
        uiResource.GetComponentInChildren<Text>().enabled = false;

        // Reparent under purchased resources.
        uiResource.transform.SetParent(purchasedResources.transform);

        // Add Button listener to activate resource when clicked.
        uiResource.GetComponent<Button>().onClick.AddListener(() => ActivateResource(resource.name));
    }

    private void ActivateResource(string name)
    {
        // Get Resource and UI from hash table by name.
        Resource resource = (Resource)nameToGO[name];
        GameObject uiResource = (GameObject)nameToUI[name];

        // If resource successfully activated, disable UI and move to activatedResources.
        if (resource.ActivateResource())
        {
            uiResource.SetActive(false);
            uiResource.transform.SetParent(activatedResources.transform);
        }
    }
}
