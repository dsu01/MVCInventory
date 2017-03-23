function FacilityComponentController() {
}

angular.module('FacilitiesApp.components', ['FacilitiesApp.controllers'])
.component('facilityComponent', {
    templateUrl: 'Partials/FacilityComponent.html',
    controller: FacilityComponentController,
    //controller: 'FacilitiesController',
    bindings: {
        //currentFacility: '='
        currentFacility: '=999'
    }
})
;