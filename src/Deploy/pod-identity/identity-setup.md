## Create an Azure Identity to use for the running pod

````

az identity create -g rg-mxinfo-kube -n barney-webui -o json

````


## Capture the following from the output json

clientId
id


These values will be used for the client id and resource id in the AzureIdentity definition

clientId: 516c66be-63a2-4f64-add3-8493c096ecff
id: /subscriptions/bb0c99b7-d44d-413a-b294-564466712637/resourcegroups/rg-mxinfo-kube/providers/Microsoft.ManagedIdentity/userAssignedIdentities/barney-webui

Copy these values into the pod-identity.yaml file



## Set the Permissions for the Managed Identity

### Find the service principal used by the cluster

````
az aks show -g rg-mxinfo-kube -n mxinfo-kube --query servicePrincipalProfile.clientId -o tsv

````

7a01e051-5bd4-4d47-ba4b-f9d9845e4883


### Assign The Required Permissions

````

az role assignment create --role "Managed Identity Operator" --assignee 7a01e051-5bd4-4d47-ba4b-f9d9845e4883 --scope <full id of the managed identity>

az role assignment create --role "Managed Identity Operator" --assignee 7a01e051-5bd4-4d47-ba4b-f9d9845e4883 --scope /subscriptions/bb0c99b7-d44d-413a-b294-564466712637/resourcegroups/rg-mxinfo-kube/providers/Microsoft.ManagedIdentity/userAssignedIdentities/barney-webui

````

The full id is the id of the identity created in az identity create

Principal Id from output of role assignment create

1b80a719-a989-40f6-b0b7-8f8c95f1c45d


### Grant the Azure AD Identity the pod is running under Key Vault Permissions

Principal Id: 1b80a719-a989-40f6-b0b7-8f8c95f1c45d
Client Id: 516c66be-63a2-4f64-add3-8493c096ecff


Get the Key Vault Id for prod-usaf-config-secrets

````
az keyvault list
````

/subscriptions/bb0c99b7-d44d-413a-b294-564466712637/resourceGroups/rg-aks-vaults/providers/Microsoft.KeyVault/vaults/mx-aks-vaults-config


### Assign Reader Role to new Identity for the configuration keyvault

````
az role assignment create --role Reader --assignee <principal id> --scope <Key Vault Id>

````

````
az role assignment create --role Reader --assignee 516c66be-63a2-4f64-add3-8493c096ecff --scope /subscriptions/bb0c99b7-d44d-413a-b294-564466712637/resourceGroups/rg-aks-vaults/providers/Microsoft.KeyVault/vaults/mx-aks-vaults-config

````

### Create an Access Policy in the Key Vault to give the identity for the pod to read secrets

````
az keyvault set-policy -n mx-aks-vaults-config --secret-permissions get --spn 516c66be-63a2-4f64-add3-8493c096ecff

````

The grant of the access can be verified by viewing the Access Policies on the Azure Key Vault.  There should be an entry for the managed identity in the list of access policies.


## Create the Azure Identity and Binding for the identity

````

kubectl apply -f pod-identity.yaml -n production

````

## Deploy the application