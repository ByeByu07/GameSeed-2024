using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [ShowInInspector]
    private IInteractable selectedBuilding;
    [ShowInInspector]
    private List<Troop> troopList;
    [SerializeField] private GameInput gameInput;
  
    private Vector3 lastInteractDir;
    public float interactDistance = 0.2f;
    public LayerMask buildingLayer;
    public float sphereRadius = 2f;
    public float castDistance = 1f;

    public event EventHandler<OnSelectedBuildingChangedEventHandler> OnSelectedBuildingChanged;
    public class OnSelectedBuildingChangedEventHandler : EventArgs {
        public IInteractable building;
    };

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        troopList = new List<Troop>();
        gameInput.OnInteractAction += GameInput_OnInteractAction;
        gameInput.OnInteractAlternateAction += GameInput_OnInteractAlternateAction;
        gameInput.OnInteractAlternate2Action += GameInput_OnInteractAlternate2Action;
    }

    private void GameInput_OnInteractAlternate2Action(object sender, EventArgs e)
    {
        if (troopList != null)
        {
            foreach (Troop troop in troopList)
            {
                if (troop == null)
                {
                    troopList.Remove(troop);
                }
                troop.SetDestination(transform);
            }
        }
    }

    private void GameInput_OnInteractAlternateAction(object sender, System.EventArgs e)
    {
        if(selectedBuilding != null)
        {
            selectedBuilding.InteractAlternate();
        }
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        if(selectedBuilding != null)
        {
            selectedBuilding.Interact();
        }
    }

    private void Update()
    {
        HandleInteraction();
    }

    void HandleInteraction()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, sphereRadius, buildingLayer);

        if (hitColliders.Length > 0)
        {
            foreach (Collider hitCollider in hitColliders)
            {
                if (hitCollider.TryGetComponent(out Troop troop))
                {
                    if (!troopList.Contains(troop))
                    {
                        troopList.Add(troop);
                    }
                }

                if (hitCollider.TryGetComponent(out IInteractable building))
                {
                    if (building != selectedBuilding)
                    {
                        SetSelectedBuilding(building);
                        Debug.Log("exist");
                        break;
                    }
                }


                //else
                //{
                //    Debug.Log("null");
                //    SetSelectedBuilding(null);
                //}
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sphereRadius);
    }

    void SetSelectedBuilding(IInteractable selectedBuilding)
    {
        this.selectedBuilding = selectedBuilding;
        OnSelectedBuildingChanged?.Invoke(this, new OnSelectedBuildingChangedEventHandler { building = selectedBuilding });
    }
}
