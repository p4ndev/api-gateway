import { useEffect, useState } from 'react'

type Props = {
    UF : "ac" | "sp" | "to"
};

export default function State({ UF } : Props) {

    const [total, setTotal] = useState(0);

    useEffect(() => {
  
        fetch("/state/" + UF)
          .then(j => j.json())
          .then(d => setTotal(d));
    
    }, []);

    return (
        <h2>{ UF } | {total}</h2>
    );

}
