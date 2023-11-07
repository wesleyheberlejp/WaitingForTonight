using System.Collections.Generic;
using UnityEngine;

public class SistemaParticulasComportamento : MonoBehaviour
{
    private List<Particulas> _listaSprites;
    private ParticleSystem.Particle[] _particulas;
    private ParticleSystem _sistemaParticulas;
    private ParticleSystemRenderer _particuleSystemRender;
    private MaterialPropertyBlock _materialPropertyBlock;
    private Dictionary<uint, bool> _particulasChecked;

    [SerializeField]
    public List<Particulas> listaSprites;

    void Start()
    {
        _listaSprites = new List<Particulas>();
        _sistemaParticulas = gameObject.GetComponent<ParticleSystem>();
        _particuleSystemRender = gameObject.GetComponent<ParticleSystemRenderer>();
        _materialPropertyBlock = new MaterialPropertyBlock();
        _particulas = new ParticleSystem.Particle[_sistemaParticulas.main.maxParticles];
        _particulasChecked = new Dictionary<uint, bool>();

    }

    void Update()
    {
        int activeParticles = GetComponent<ParticleSystem>().GetParticles(_particulas);

        if (activeParticles > 0)
        {
            for (int i = 0; i < activeParticles; i++)
            {

                ParticleSystem.Particle particula = _particulas[i];

                if (particula.remainingLifetime > 0f)
                {
                    if (!_particulasChecked.ContainsKey(particula.randomSeed))
                    {
                        _particulasChecked.Add(particula.randomSeed, true);
                        AlterarSprite();
                    }
                }
            }
        }

    }

    private void AlterarSprite()
    {
        if (!conferirListaPreenchida())
        {
            _listaSprites.AddRange(listaSprites);
        }

        var _sprite = obterParticula();

        _materialPropertyBlock.SetTexture("_MainTex", _sprite.Material.texture);
        Shader unlitTransparentShader = Shader.Find("Unlit/Transparent");

        if (unlitTransparentShader != null)
        {

            _materialPropertyBlock.SetFloat("_Mode", 2);
            _materialPropertyBlock.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            _materialPropertyBlock.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            _materialPropertyBlock.SetInt("_ZWrite", 0);
            _materialPropertyBlock.SetFloat("_AlphaCutoff", 0.5f);
            _materialPropertyBlock.SetInt("_ColorMask", (int)UnityEngine.Rendering.ColorWriteMask.All);
            _materialPropertyBlock.SetFloat("_Scale", _sprite.Tamanho);
            _particuleSystemRender.material = new Material(unlitTransparentShader);
        }
        _particuleSystemRender.SetPropertyBlock(_materialPropertyBlock);

    }

    public Particulas obterParticula()
    {
        
        System.Random _random = new System.Random();

        var indiceSorteado = _random.Next(_listaSprites.Count);
        var particula = _listaSprites[indiceSorteado];

        _listaSprites.RemoveAt(indiceSorteado);
        
        return particula;
    }

    private bool conferirListaPreenchida()
    {
        return _listaSprites.Count > 0;
    }

}
