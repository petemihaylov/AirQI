export default function Layout(props) {

    return (
        <div>
            {Array.isArray(props.collection) && props.collection.length && props.collection.map(function (station, index) {
                return (
                    <div key={index}>
                        {index}. Station: {station.location} Data: {station.createdAt}
                    </div>
                )
            })}
        </div>
    );

}