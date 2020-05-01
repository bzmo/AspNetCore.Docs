import { appV1 } from "./appV1";
import { appV2 } from "./appV2";

async function main() : Promise<void> {
    console.log("Testing TS Generated Clients");
    process.env["NODE_TLS_REJECT_UNAUTHORIZED"] = '0';

    await appV1.SendAPIRequests();

    console.log("<--------------------------->");

    await appV2.SendAPIRequests();
}

main().then(() => {
    // Pause to see console
    setTimeout(null, 10000);
});