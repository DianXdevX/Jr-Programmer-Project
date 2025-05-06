using UnityEngine;

public class ProductivityUnit : Unit //  o C# nao  permite heranca  mutilpla por isso o monobehauvor foi  deletado.
{
    // new variables
    private ResourcePile m_CurrentPile = null; //   isso aqui  vai apontar  para a  pilhad e recusos no qual eu clikei 
    public float ProductivityMultiplier = 2; 
    protected override void BuildingInRange()
    {
        // start of new code
        if (m_CurrentPile == null)  // se  mpiule    for igual  a nada  ou seja sem alvo 
        {
            ResourcePile pile = m_Target as ResourcePile;  //     pegue  o novo alvo 

            if (pile != null) // se    nao for nulo     a pilah e  a pilha que ja esta 
            {
                m_CurrentPile = pile;
                m_CurrentPile.ProductionSpeed *= ProductivityMultiplier; // mutiplicador de velocidade 
            }
        }
        // end of new code
    }
    void ResetProductivity() //reseta o valor de protudividade para o origina 
    {
        if (m_CurrentPile != null)  // se   a mplius efor   true  
        {
            m_CurrentPile.ProductionSpeed /= ProductivityMultiplier; //divid o valor da pilha pelo spped
            m_CurrentPile = null; //e torna  a pilha nula 
        }
    }
    public override void GoTo(Building target)
    {
        ResetProductivity(); // call your new method
        base.GoTo(target); // run method from base class
    }
    public override void GoTo(Vector3 position)
    {
        ResetProductivity();
        base.GoTo(position);
    }
}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  
