import React, { useState, useEffect } from "react";

function Check() {
    const [data, setData] = useState([]); // Holds the fetched data
    const [error, setError] = useState(null); // Holds any error encountered
    const [loading, setLoading] = useState(true); // Tracks the loading state

    useEffect(() => {
        fetch("http://localhost:8080/book") // Changed to http:// for local development
            .then((res) => {
                if (!res.ok) {
                    throw new Error(`HTTP error! status: ${res.status}`);
                }
                return res.json();
            })
            .then((result) => {
                setData(result); // Save the fetched data
                setLoading(false); // Stop loading
            })
            .catch((error) => {
                setError(error.message); // Capture the error message
                setLoading(false); // Stop loading
            });
    }, []);

    // Render loading state
    if (loading) {
        return <p>Loading...</p>;
    }

    // Render error state
    if (error) {
        return <p>Error: {error}</p>;
    }

    // Render the data
    return (
        <div>
            <h1>Fetched Data</h1>
            <ul>
                {data.map((item, index) => (
                    <li key={index}>
                        {JSON.stringify(item)} {/* Adjust based on API structure */}
                    </li>
                ))}
            </ul>
        </div>
    );
}

export default Check;
