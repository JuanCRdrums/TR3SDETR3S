
import './App.css';
import { useState } from "react";
import ReactDOM from "react-dom";
import API from "./API";
function App() {

  const [n1, setN1] = useState(0);
  const [n2, setN2] = useState(0);
  const [msg, setMsg] = useState("");

  const handleN1Change = (e) => {
    setN1(e.target.value);
  }

  const handleN2Change = (e) => {
    setN2(e.target.value);
  }

  const calcTotal = () => {
    if(Number(n1) > 0 && Number(n2) > 0)
    {
      let body = {
        'n1': n1,
        'n2': n2
      };
      API.post("", body).then((response) => {
        let text = "El resultado de la suma es " + response.data.result + ". Este número ";
        if(response.data.fibonacci)
          text += "pertenece a la serie de fibonacci (primeros 100 números).";
        else
          text += "no pertenece a la serie de fibonacci (primeros 100 números)."

        setMsg(text);
      })
    }
    else
    {
      setMsg("Por favor ingrese 2 números mayores que 0");
    }
    
  }

  return (
    <div className="App">
      <h1>Prueba técnica TR3SDETR3S</h1>
      <h3>Suma de dos números</h3>

      <div className="number-inputs">
        <input type="number" onChange={handleN1Change} value={n1} />
        <input type="number" onChange={handleN2Change} value={n2} />
      </div>

      <button onClick={calcTotal}>Calcular</button>

      <h3>{msg}</h3>
    </div>
  );
}

export default App;
