import pandas as pd

flightActivity = pd.read_csv('Customer Flight Activity.csv')
loyaltyDataDictionary = pd.read_csv('Airline Loyalty Data Dictionary.csv')
loyaltyHistory = pd.read_csv('Customer Loyalty History.csv')

print(flightActivity.head())
print(loyaltyDataDictionary.head())
print(loyaltyHistory.head())

merged_df = pd.merge(
    flightActivity,
    loyaltyHistory,
    on='Loyalty Number',
    how='outer',
    indicator=True
)

print("Результат MERGE з indicator:")
print(merged_df.head())

fa_join = flightActivity.set_index('Loyalty Number')
lh_join = loyaltyHistory.set_index('Loyalty Number')

joined_df = fa_join.join(lh_join, how='inner', lsuffix='_fa', rsuffix='_lh')

print("\nРезультат JOIN по індексу:")
print(joined_df.head())