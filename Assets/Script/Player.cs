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
    [SerializeField] private ParticleSystem playerSelectTroopsEffect;

    private bool isTryGetTroops = false;
    private Vector3 lastInteractDir;
    public float interactDistance = 0.2f;
    public LayerMask buildingLayer;
    public LayerMask troopLayer;
    public float sphereRadius = 2f;
    public float castDistance = 1f;

    public event EventHandler<OnSelectedBuildingChangedEventHandler> OnSelectedBuildingChanged;
    public class OnSelectedBuildingChangedEventHandler : EventArgs {
        public IInteractable building;
    };

    private void Awake()
    {
        Instance = this;
        troopList = new List<Troop>();
    }

    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
        gameInput.OnInteractAlternateAction += GameInput_OnInteractAlternateAction;
        gameInput.OnInteractAlternate2Action += GameInput_OnInteractAlternate2Action;
    }

    private void GameInput_OnInteractAlternate2Action(object sender, EventArgs e)
    {
        EmitParticleSelectedTroops(playerSelectTroopsEffect);
        isTryGetTroops = true;

        if (troopList != null)
        {
            foreach (Troop troop in troopList)
            {
                troop.SetDestination(transform);
            }

            troopList = null;
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
        //UpdateTroops();
    }

    void HandleInteraction()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, sphereRadius);
        Collider[] troopColliders = Physics.OverlapSphere(transform.position, sphereRadius, troopLayer);

        if (hitColliders.Length > 0)
        {
            foreach (Collider hitCollider in hitColliders)
            {
                if (hitCollider.TryGetComponent(out IInteractable building))
                {
                    if (building != selectedBuilding)
                    {
                        SetSelectedBuilding(building);
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

        if (troopColliders.Length > 0 & isTryGetTroops)
        {
            foreach (Collider hitCollider in troopColliders)
            {
                if (hitCollider.TryGetComponent(out Troop troop) & isTryGetTroops)
                {
                    if (!troopList.Contains(troop))
                    {
                        troopList.Add(troop);
                    }
                }
            }
            isTryGetTroops = false;
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

    private void EmitParticleSelectedTroops(ParticleSystem ps)
    {
        ps.gameObject.SetActive(true);
        if (!ps.isPlaying) ps.Play();
        if (ps.isPlaying) ps.Stop();
        if (ps.isPlaying) ps.Stop();
        if (!ps.isPlaying) ps.Play();
    }

    public void UpdateTroops()
    {
        foreach (Troop troop in troopList)
        {
            if (troop == null)
            {
                troopList.Remove(troop);
            }
        }
    }
}
