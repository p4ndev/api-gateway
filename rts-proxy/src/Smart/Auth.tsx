import { useEffect } from 'react'

export default function Auth() {

    useEffect(() => {
  
        let tmp = new Date().getMilliseconds();
        let model = { email: `aaa_${tmp}@aol.com.br`, password: "dfsgdfg34" };

        fetch('/auth', {
            method: "POST",
            body: JSON.stringify(model),
            headers: {"Content-type": "application/json;charset=UTF-8" }
        })
            .then(j => j.json())
            .then(d => console.log(d));
    
    }, []);

    return (<h1>Authentication loading...</h1>);

}