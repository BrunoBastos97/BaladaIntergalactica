import {useState, useEffect} from "react";
import Menu from '../styles/component/menu.js'

export default function Balada() {
  const [name, setName] = useState(null);

  console.log(name);

  function cadastrarBalada() {

  var model = { 
    name: name,
  }

    fetch('https://localhost:5001/api/ballad',{ method: 'POST', body: JSON.stringify(model), headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'}
    })
    .then(respond => {
      if(!respond.ok){
        throw Error(respond.statusText);
      }
      return respond
    })
    .catch(e => alert('Erro: Verifique os campos', e)) 
  
  }
 
  return (
    <div>
      <Menu/>
      <form>
        <center>
        <h2>Nome</h2><br/>
        <input type="text"  onChange={e =>  setName(e.target.value)}/><br/>
        <button onClick={(evento) => {
            evento.preventDefault()
            cadastrarBalada()}
          }>Cadastrar</button>
        </center>
      </form>
    </div>
  )
}
