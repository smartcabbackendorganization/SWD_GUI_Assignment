// Vue code for the Music page
vm = new Vue({
    el: '#SensorApp',
    data: {
        sensors: ["hej", "hej"],
        loading: false
    },
    methods: {
    },
    mounted() {
        // Get all upcomming music arrangements
        fetch('/manage/sensors').then(function (response) {
            if (response.status !== 200) {
                console.log('Looks like there was a problem. Status Code: ' + response.status);
                return;
            }

            response.json().then(function (sensors) {

                console.log("LOL?");
                vm.loading = false;
                console.log(sensors)
                vm.sensors = sensors;
                })
                .catch(function (err) {
                    console.log('Fetch Error :-S', err);
                });
        });
    }
});