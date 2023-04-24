import { useEffect, useState } from 'react'

export default function Forecast() {

    const [forecast, setForecast] = useState([]);

    useEffect(() => {
  
        fetch("/forecast")
          .then(j => j.json())
          .then(d => setForecast(d));
    
    }, []);

    return (
        <>
            <h1>Random three forecast</h1>
            { JSON.stringify(forecast) }
        </>
    );

}