import {useState, useEffect} from "react";
import Menu from '../styles/component/menu.js'


export default function CheckOut() {
    
  const [id, setId] = useState(null);
  const[checkIns, setCheckIns] = useState([{id: 0,  ballad:{name: 'Nome da balada'}, alien:{name: 'Nome do Alien'}}]);

  function cadastrarCheckout() {
    var model = {  
      id: id
    }
  
      fetch(`https://localhost:5001/api/CheckinCheckout/Checkout/${id}`, { method: 'PUT', body: JSON.stringify(model), headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'}
      })
      .then(respond => {
        if(!respond.ok){
          throw Error(respond.statusText);
        }
        return respond
      })
      .catch(e => alert('Erro: Verifique os campos do Check Out', e)) 
      .then(e => console.log(e)) 
  }

  useEffect(
    async () => {
      var result = await fetch('https://localhost:5001/api/CheckInCheckOut',{ method: 'GET', headers: {
         'Accept': 'application/json',
         'Content-Type': 'application/json'}
       })
 
       var data = await result.json();
       var listCheckIn = [
         {id: 0, ballad:{name: 'Nome da Balada'}, alien:{name: 'Nome do Alien'}},
         ...data
       ];
       
       setCheckIns(listCheckIn);
     },[]
   ) 

  function checkOut(al) {
    console.log(al);
    setId(al);
  }

  return (
    <div>
      <Menu/>
      <form>
        <center>
            <h2>Nome do Alien e Balada</h2><br/><br/><br/>
            <select onChange={event => checkOut(event.target.value)}> 
              {
                checkIns.map(
                  (item, index) =>  <option key={index} value={item.id}>{`${item.ballad.name} - ${item.alien.name}`}</option>
                )
              }        
            </select><br/>
            <button onClick={(evento) => {
              evento.preventDefault()
              cadastrarCheckout()
              }}>Check Out</button>
        </center>
      </form>
      </div>
  )
}