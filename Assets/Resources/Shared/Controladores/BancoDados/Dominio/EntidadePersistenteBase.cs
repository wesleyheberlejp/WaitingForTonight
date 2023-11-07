using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntidadePersistenteBase
{
    // todas as classes de dominio que serão persistidas no banco de dados precisam herdar desta classe
    public int ID { get; set; }
}
