using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroducaoCenaControlador : MonoBehaviour
{
    public static IntroducaoCenaControlador Intro;
    public GameObject UiIntro;
    private GameObject CRUDPrefab;
    private GameObject DBPrefab;
    private bool ProximaCenaCarregada = false;
    public ManagerGameControlador Game;


    const string CenaMenu = "MENUPRINCIPAL";
    const string PastaPrefabs = "Shared/Cenas/INTRODUCAO";
    public float DuraçãoIntrodução = 5.0f;
    [SerializeField]
    private string NomeCenaPosIntroducao;

    private GameObject InstanciarGameObjectPrefabDeResources(string nomePrefab)
    {
        GameObject instance = null;

        var objetos = PastaPrefabs.ObterArquivos();

        foreach (var item in objetos)
        {
            if ((item.name == nomePrefab) && (item is GameObject))
            {
                instance = Instantiate((GameObject)item);
                break;
            }
        }
        return instance;

    }

    private float timer = 0.0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= DuraçãoIntrodução)
        {
            CarregarCenaMenu();
        }
    }

    void CarregarCenaMenu()
    {
        if (!ProximaCenaCarregada)
        {
            if (NomeCenaPosIntroducao == string.Empty)
            {
                NomeCenaPosIntroducao = CenaMenu;
            }

            SceneManager.LoadScene(NomeCenaPosIntroducao, LoadSceneMode.Additive);
            ProximaCenaCarregada = true;
            UiIntro.SetActive(false);
        }
    }
    private void Awake()
    {

        DBPrefab = InstanciarGameObjectPrefabDeResources("BANCODADOS");
        CRUDPrefab = InstanciarGameObjectPrefabDeResources("CRUD");
        Intro = this;
    }

    private void Start()
    {
        Game = CRUDPrefab.GetComponent<ManagerGameControlador>();
    }


}
