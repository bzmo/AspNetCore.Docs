"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
Object.defineProperty(exports, "__esModule", { value: true });
const appV1_1 = require("./appV1");
const appV2_1 = require("./appV2");
function main() {
    return __awaiter(this, void 0, void 0, function* () {
        console.log("Testing TS Generated Clients");
        process.env["NODE_TLS_REJECT_UNAUTHORIZED"] = '0';
        yield appV1_1.appV1.SendAPIRequests();
        console.log("<--------------------------->");
        yield appV2_1.appV2.SendAPIRequests();
    });
}
main().then(() => {
    // Pause to see console
    setTimeout(null, 10000);
});
//# sourceMappingURL=app.js.map