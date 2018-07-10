import { $http } from "@/services/http-common";

const services = {
    getCurrencyList,
    convert
};
export default services;

function getCurrencyList() {
	return $http.get(`api/currencies/list`);
}
function convert(from, to, amount) {
	return $http.get(`api/currencies/${from}/${to}/${amount}`);
}